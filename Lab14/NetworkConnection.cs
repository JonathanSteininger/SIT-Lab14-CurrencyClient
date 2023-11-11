using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace Lab14
{
    internal class NetworkConnection
    {
        private string _ip;
        private int _port;

        private TcpClient _tcpClient;
        private NetworkStream _stream;
        private BinaryReader _reader;
        private BinaryWriter _writer;


        public NetworkConnection(string IP, int Port)
        {
            this._ip = IP;
            this._port = Port;
            Connect();
        }
        public void Connect()
        {
            if (this._tcpClient != null) return;
            _tcpClient = new TcpClient(_ip, _port);
            _stream = _tcpClient.GetStream();
            _writer = new BinaryWriter(_stream);
            _reader = new BinaryReader(_stream);
        }
        public object Request(object message)
        {
            try
            {
                Send(message);
                return Recive();    
            }catch (Exception e)
            {
                throw new Exception($"Request to Server Failed. Server:{_ip}:{_port}. ", e);
            }
        }
        public void Send(object message)
        {
            try
            {
                _writer.Write(JSONFactory.SerialiseObject(message));
            }
            catch (Exception ex)
            {
                throw new Exception("Failed sending object to server.", ex);
            }
        }

        public object Recive()
        {
            try
            {
                string jsonResponse = _reader.ReadString();
                return JSONFactory.DesialiseObject(jsonResponse);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed reading object from server.", ex);
            }
        }

        public void Close()
        {
            _writer?.Close();
            _reader?.Close();
            _stream?.Close();
            _tcpClient?.Close();
        }
    }
}
