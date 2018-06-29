using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Path
{
    public class Path
    {
        public string CurrentPath { get; private set; }
        private readonly LinkedList<string> _path;

        public Path(string path)
        {
            this._path = new LinkedList<string>(path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries));
            SetCurrPath();
        }

        private void SetCurrPath()
        {
            var builder = new StringBuilder();
            foreach (var element in _path)
                builder.Append("/").Append(element);
            CurrentPath = builder.ToString();
        }

        public void Cd(string newPath)
        {
            var elements = new LinkedList<string>(newPath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries));
            if (newPath.StartsWith("/"))
                _path.Clear();

            foreach (var element in elements)
            {
                if (element == "..")
                    _path.RemoveLast();
                else
                    _path.AddLast(element);
            }
            SetCurrPath();
        }
    }
}
