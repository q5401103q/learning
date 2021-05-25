using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Liuzl.Tutorial.Samples
{
    class Demo016
    {
        public static void Test()
        {
            var worker = new Worker();

            Console.WriteLine("主线程：启动工作线程...");
            var workerTask = Task.Run(worker.DoWork);

            // 等待 500 毫秒以确保工作线程已在执行
            Thread.Sleep(500);

            Console.WriteLine("主线程：请求终止工作线程...");
            worker.RequestStop();

            // 待待工作线程执行结束
            workerTask.Wait();

            Console.WriteLine("主线程：工作线程已终止");
        }
    }

    public class Worker
    {
        //注意定义为 volatile
        private volatile bool _shouldStop;

        public void DoWork()
        {
            bool work = false;

            // 注意：不定义为volatile，这里会被编译器优化
            while (!_shouldStop)
            {
                work = !work; // do sth.
            }
            Console.WriteLine("工作线程：正在终止...");
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }
    }
}
