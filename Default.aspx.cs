
/*DS Lab 3 
 Author - Harsh Mukesh Langalia
 1001372136 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using System.Web.Routing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;


public partial class _Default : System.Web.UI.Page
{
    //TcpClient myclient = new TcpClient();
	
	//gloabl declarations
    weather.ndfdXML currentweather = new weather.ndfdXML();
    decimal lat;// to take lattitude from user
    decimal lng; //to take longitudefrom user
    weather.weatherParametersType Paramtype = new weather.weatherParametersType();
    string xmlstmt;



    protected void Page_Load(object sender, EventArgs e)
    {
        
        //no action required on page load        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            weather.ndfdXML currentweather = new weather.ndfdXML(); // creating onbject currentweather of class weather.ndfdXML
            //Console.WriteLine(currentweather); //printing on console for debugging and tracing data
            decimal lat = Convert.ToDecimal(TextBox1.Text);
            decimal lng = Convert.ToDecimal(TextBox2.Text);
            // lat = 32.7452M;
            Console.WriteLine(lat);//printing on console for debugging and tracing data
            //decimal lng = -117.1979M;
            Console.WriteLine(lng);//printing on console for debugging and tracing data
            weather.weatherParametersType Paramtype = new weather.weatherParametersType();
            //Console.WriteLine(wtp);//printing on console for debugging and tracing data
            //Label2.Text =Convert.ToString(Paramtype);
            Paramtype.temp = true;//parameter required from the web service
            // wind speed
            Paramtype.wspd = true;//parameter required from the web service
            //wind Direction
            Paramtype.wdir = true;//parameter required from the web service
            //Wave height
            Paramtype.waveh = true;//parameter required from the web service
	//dew precipitation
            Paramtype.dew = true;//parameter required from the web service
		//ice accumulation
            Paramtype.iceaccum = true;//parameter required from the web service
		//max temperature
            Paramtype.maxt = true;//parameter required from the web service
		// min temperature
            Paramtype.mint = true;//parameter required from the web service

            xmlstmt = currentweather.NDFDgen(lat, lng, weather.productType.timeseries, DateTime.Now, DateTime.Now, weather.unitType.e, Paramtype); //calling web service
            Console.WriteLine(xmlstmt);//printing on console for debugging and tracing data
            Console.WriteLine("SOAP RESPONSE");//printing on console for debugging and tracing data
            Label1.Text = xmlstmt;
            string xmlstmt1 = xmlstmt.Substring(xmlstmt.IndexOf("Temperature"));//stripping required responses from the response string
            Label2.Text = xmlstmt1;

        }
        catch (Exception ee)
        {
            Console.WriteLine(ee);
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        try
        {
           // weather.ndfdXML currentweather = new weather.ndfdXML();
            //Console.WriteLine(currentweather);//printing on console for debugging and tracing data
           lat = Convert.ToDecimal(TextBox1.Text);
            lng = Convert.ToDecimal(TextBox2.Text);
           
            Console.WriteLine(lat);//printing on console for debugging and tracing data
            //decimal lng = -117.1979M;
            Console.WriteLine(lng);//printing on console for debugging and tracing data
            //weather.weatherParametersType Paramtype = new weather.weatherParametersType();
            //Console.WriteLine(wtp);//printing on console for debugging and tracing data
            //Label2.Text =Convert.ToString(paramtype);
            Paramtype.temp = true;//parameter required from the web service
            // wind speed
            Paramtype.wspd = true;//parameter required from the web service
            //wind Direction
            Paramtype.wdir = true;//parameter required from the web service
            //Wave height
            Paramtype.waveh = true;//parameter required from the web service
	//dew precipitation
            Paramtype.dew = true;//parameter required from the web service
		//ice accumulation
            Paramtype.iceaccum = true;//parameter required from the web service
		//max temperature
            Paramtype.maxt = true;//parameter required from the web service
		// min temperature
            Paramtype.mint = true;//parameter required from the web service

            xmlstmt = currentweather.NDFDgen(lat, lng, weather.productType.timeseries, DateTime.Now, DateTime.Now, weather.unitType.e, Paramtype);//calling web service
            Console.WriteLine(xmlstmt);//printing on console for debugging and tracing data
            Console.WriteLine("SOAP Refresh RESPONSE");//printing on console for debugging and tracing data
            Label3.Text = xmlstmt;
            string xmlstmt2 = xmlstmt.Substring(xmlstmt.IndexOf("Temperature"));//stripping required responses from the response string
            Label2.Text = xmlstmt2;

        }
        catch (Exception ee)
        {
            Console.WriteLine(ee);
        }

    }
}