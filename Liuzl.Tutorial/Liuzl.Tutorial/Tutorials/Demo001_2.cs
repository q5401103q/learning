using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Tutorials
{
    class ProfileController
    {
        public async void Test()
        {
            //常见示例1：各种流，例如文件流
            var stream = new FileStream("", FileMode.Open);
            await stream.ReadAsync(new byte[1]);
            await stream.WriteAsync(new byte[1]);

            //常见示例2：网络请求
            var http = new HttpClient();
            await http.SendAsync(new HttpRequestMessage());
            await http.GetStringAsync("http://uri");

            //常见示例3：网络连接，如socket，xxConnection等
            var socket = new Socket(new AddressFamily(), SocketType.Stream, ProtocolType.Tcp);
            socket.ConnectAsync(new SocketAsyncEventArgs());
            socket.ReceiveAsync(new SocketAsyncEventArgs());
            socket.SendAsync(new SocketAsyncEventArgs());

            //常见示例4：委托、事件
            var delegatee = new Func<string, int>((aa) => {
                return Convert.ToInt32(aa);
            });
            var task = Task<int>.Factory.FromAsync(delegatee.BeginInvoke, delegatee.EndInvoke, "32", null);

            //常见示例5：Context例如EFContext等
        }
    }
}
