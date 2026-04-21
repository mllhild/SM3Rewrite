using System;
using System.Text.RegularExpressions;

namespace SM3Rewrite
{
    public class Name
    {
        public string surename;
        public string name;
        public string middleName;
        public string title;
        public string nickName;
        public void SetName(string name = "", string surename = "", string middleName = "", string nickName = "")
        {
            this.name = name;
            this.surename = surename;
            this.middleName = middleName;   
            this.nickName = nickName;
        }
        public void SetTitle(string title)
        {
            this.title = title;
        }
        public string GetName() => this.name;
        public string GetSurname() => this.surename;
        public string GetMiddleName() => this.middleName;
        public string GetMiddleNameSurname() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] { middleName, surename }));
        public string GetFullName() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] { name, middleName, surename }));
        public string GetFullNameWithShortMiddle() =>
            RemoveDuplicateWhitespace(String.Join(" ", new[] { name, middleName.Length > 0 ? middleName.Substring(0, 1) + "." : "", surename }));
        public string GetFullNameJP() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] {  middleName, surename, name })); 
        public string GetFullNameWithTitle() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] { title, name, middleName, surename}));
        public string GetNameWithTitle() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] { title, middleName, surename }));
        public string GetNameWithTitleWithoutMiddleName() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] { title, surename }));
        public string GetInnitials() => 
            RemoveDuplicateWhitespace(String.Join(" ", new[] { 
            name.Length > 0 ? name.Substring(0,1)+"." : "",
            middleName.Length > 0 ? middleName.Substring(0,1)+"." : "",
            surename.Length > 0 ? surename.Substring(0,1)+"." : "",  }));

        public string RemoveDuplicateWhitespace(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            return Regex.Replace(text.Trim(), @"\s+", " ");
        }
    }
}
