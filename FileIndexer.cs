using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SM3Rewrite
{
    public class FileIndexer {

        /// <summary>
        /// Creates dictionary of all file paths
        /// Keys are created as keybase$Dic$subdic$subdic$filename
        /// Value is the filepath
        /// </summary>
        /// <param name="path"></param>
        /// <param name="checkSubfolder"></param>
        /// <param name="extensions">extension with dot ".png"</param>
        /// <param name="keyBase">leave empty</param>
        /// <returns></returns>
        public Dictionary<string,string> IndexFiles(
            string path, 
            bool checkSubfolder = true,
            string[] extensions = null,
            string keyBase = "") 
        { 
            Dictionary<string,string> dic = new Dictionary<string,string>();
            if(!System.IO.Directory.Exists(path))
                return dic;
            List<string> files = System.IO.Directory.GetFiles(path).ToList<string>();
            List<string> subdics = System.IO.Directory.GetDirectories(path).ToList<string>();
            //if(extensions == null)
            //    extensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
            
            foreach (string file in files) {
                if(extensions == null || extensions.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                    dic[keyBase + "$" + System.IO.Path.GetFileName(file)] = file;
            }
            
            if(!checkSubfolder)
                return dic;

            foreach (string subdic in subdics)
            {
                Dictionary<string, string> dicsub = 
                    IndexFiles(subdic, 
                    checkSubfolder,
                    extensions,
                    keyBase + "$" + System.IO.Path.GetDirectoryName(subdic));
                foreach(var dicEntry in  dicsub)
                    dic[dicEntry.Key] = dicEntry.Value;
            }
            
            return dic;
        }

        /// <summary>
        /// Creates dictionary of all files
        /// Keys are created as keybase$Dic$subdic$subdic$filename
        /// Value is the file as Binary data via File.ReadAllBytes
        /// </summary>
        /// <param name="path"></param>
        /// <param name="checkSubfolder"></param>
        /// <param name="extensions">extension with dot ".png"</param>
        /// <param name="keyBase">leave empty</param>
        /// <returns></returns>
        public Dictionary<string, object> LoadFiles(
            string path,
            bool checkSubfolder = true,
            string[] extensions = null,
            string keyBase = "") 
        { 
            Dictionary<string, object> dic = new Dictionary<string, object>();
            if (!System.IO.Directory.Exists(path))
                return dic;
            List<string> files = System.IO.Directory.GetFiles(path).ToList<string>();
            List<string> subdics = System.IO.Directory.GetDirectories(path).ToList<string>();

            foreach (string file in files)
            {
                if (extensions == null || extensions.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                    dic[keyBase + "$" + System.IO.Path.GetFileName(file)] = System.IO.File.ReadAllBytes(file);
            }

            if (!checkSubfolder)
                return dic;

            foreach (string subdic in subdics)
            {
                Dictionary<string, object> dicsub =
                    LoadFiles(subdic,
                    checkSubfolder,
                    extensions,
                    keyBase + "$" + System.IO.Path.GetDirectoryName(subdic));
                foreach (var dicEntry in dicsub)
                    dic[dicEntry.Key] = dicEntry.Value;
            }

            return dic;
        }


        /// <summary>
        /// Creates dictionary of all files
        /// Keys are created as keybase$Dic$subdic$subdic$filename
        /// Value is the file as Binary data via File.ReadAllBytes
        /// </summary>
        /// <param name="path"></param>
        /// <param name="checkSubfolder"></param>
        /// <param name="extensions">extension with dot ".png"</param>
        /// <param name="keyBase">leave empty</param>
        /// <returns></returns>
        public async Task<Dictionary<string, object>> LoadFilesAsync(
            string path,
            string keyBase = "",
            string[] extensions = null)
        {
            var dic = new Dictionary<string, object>();

            if (!Directory.Exists(path))
                return dic;

            // Process files
            foreach (string file in Directory.EnumerateFiles(path))
            {
                if (extensions == null || extensions.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)))
                {
                    string key = keyBase + "$" + Path.GetFileName(file);
                    dic[key] = await ReadFileAsync(file);
                }
            }

            // Process subdirectories recursively
            foreach (string subdir in Directory.EnumerateDirectories(path))
            {
                string subKeyBase = keyBase + "$" + Path.GetFileName(subdir);

                var subDict = await LoadFilesAsync(subdir, subKeyBase, extensions);

                foreach (var entry in subDict)
                    dic[entry.Key] = entry.Value;
            }

            return dic;
        }

        private async Task<byte[]> ReadFileAsync(string file)
        {
            using (var stream = new FileStream(
                file,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                4096,
                useAsync: true))
            {
                byte[] buffer = new byte[stream.Length];
                int offset = 0;

                while (offset < buffer.Length)
                {
                    int read = await stream.ReadAsync(buffer, offset, buffer.Length - offset);
                    if (read == 0)
                        break;

                    offset += read;
                }

                return buffer;
            }
        }


    }
}
