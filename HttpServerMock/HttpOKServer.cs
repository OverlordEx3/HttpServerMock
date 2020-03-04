using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace HttpServerMock
{
    public class HttpOKServer
    {
        private int _port;
        private HttpListener _listener;
        private Task _serverTask;
        private CancellationTokenSource CtokenSource;
        public int Port
        {
            get => this._port;
            private set => this._port = value;
        }

        public HttpOKServer(int port)
        {
            this.Port = port;
            this._listener = new HttpListener();
            this.CtokenSource = new CancellationTokenSource();
            this.Initialize();
        }

        private void Initialize()
        {
            this._serverTask = new Task(() => this.Listen(CtokenSource.Token));
        }

        public void Start()
        {
            this._serverTask.Start();
        }

        public void Stop()
        {
            CtokenSource.Cancel();
        }

        private void Listen(CancellationToken cancellationToken)
        {
            _listener.Prefixes.Add("http://*:" + _port.ToString() + "/");
            _listener.Start();
            while (cancellationToken.IsCancellationRequested != true)
            {
                try
                {
                    HttpListenerContext _context = _listener.GetContext();
                    ProcessRequest(_context);
                } catch(Exception ex)
                {
                    Console.WriteLine("Exception on listener: " + ex.Message);
                }
            }
            _listener?.Stop();
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            string body;
            using(StreamReader rd = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
            {
                body = rd.ReadToEnd();
            }

            Console.WriteLine("Received request from {0}", context.Request.RemoteEndPoint.ToString());
            Console.WriteLine("Request body: {0}", body);

            try
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.OutputStream.Flush();
            } catch(Exception ex)
            {
                Console.WriteLine("Exception processing request: " + ex.Message);
            }
            context.Response.Close();
        }
    }
}
