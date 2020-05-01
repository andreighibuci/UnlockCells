using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace UnlockCells_Service
{
    public class Worker : BackgroundService
    {
        public static SerialPort iSerialPort = new SerialPort();
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        //I use this handler for every time my arduino board sends data to the serial. This handler reads the data from the serial as string and sends it forward
        // through tcp/ip protocol to the server.
        private void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {

            SerialPort sp = (SerialPort)sender;
            string _indata = sp.ReadLine();
            string ipAddres = "127.0.0.1";
            IPAddress ipAddress = IPAddress.Parse(ipAddres);
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, 44389);
            Socket socketClient = new Socket(remoteEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socketClient.Connect(remoteEndPoint);
            try {
                if (_indata.Any(char.IsDigit))
                {
                    _logger.LogInformation("Tcp communication working");
                    _logger.LogInformation("Data to be send : " + _indata);
                    byte[] data = System.Text.Encoding.ASCII.GetBytes(_indata);
                    socketClient.Send(data);
                    _logger.LogInformation("Data sent");
                }
                
            }catch(SocketException se)
            {
                _logger.LogInformation("Socket exception raised");
            }
        }
        public int OpenCom(string strPort, int nBaudrate, out string strException)
        {

            strException = string.Empty;

            if (iSerialPort.IsOpen)
            {
                iSerialPort.Close();
            }

            try
            {
                iSerialPort.PortName = strPort;
                iSerialPort.BaudRate = nBaudrate;
                iSerialPort.ReadTimeout = 3000;
                iSerialPort.DataBits = 8;
                iSerialPort.Parity = Parity.None;
                iSerialPort.StopBits = StopBits.One;
                iSerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                iSerialPort.Handshake = Handshake.None;
                iSerialPort.RtsEnable = true;

                iSerialPort.Open();
            }
            catch (System.Exception ex)
            {
                strException = ex.Message;
                return -1;
            }


          
            return 0;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string strExcept = string.Empty;
            string strComPort = "COM7";
            int nBaudrate = Convert.ToInt32(9600);
            int nRet = OpenCom(strComPort, nBaudrate,out strExcept);

            if(nRet != 0)
            {
                _logger.LogInformation("Connect reader failed due to " + strExcept);
            }
            else
            {
                _logger.LogInformation("Reader connected " + strComPort + "@" + nBaudrate.ToString());
            }    

            while (!stoppingToken.IsCancellationRequested)
            {
               
               
            }
        }
    } 
}
   
 
