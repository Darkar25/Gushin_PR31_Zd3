using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarathonApp.Core
{
    public partial class Runner
    {
        public byte[] RunnerPicture { get
            {
                if (Img == null)
                {
                    using (Stream s = this.GetType().Assembly.GetManifestResourceStream("boy.png"))
                    {
                        long l = s.Length;
                        byte[]  visibleImage = new byte[l];
                        s.Read(visibleImage, 0, (int)l);
                        return visibleImage;
                    }
                }
                else
                {
                    return Img;
                }
            } }

        public string Age { get 
            {
                return (DateTime.Now.Year - DateOfBirth.Year).ToString()+" Лет";
            } }

        public string RunnerFIO { get {
                return String.Format("{0} {1}", User?.LastName, User?.FirstName);
            } }
    }
}
