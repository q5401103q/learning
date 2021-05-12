using System;

namespace Liuzl.Tutorial.Samples
{
    public class Demo007
    {
        public delegate void OnDomClickedHandler(object sender, DomClickEventArgs e);
        public event OnDomClickedHandler OnDomClicked;

        public void Test()
        {
            OnDomClicked(this, new DomClickEventArgs() { Message = "dom clicked" });
        }
    }

    public class DomClickEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}