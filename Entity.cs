using System.Collections.Generic;
using System.Text;

namespace SM3Rewrite
{
    public class Entity
    {
        private string id;

        /// <summary>
        /// ID via Guid.NewGuid().ToString()
        /// </summary>
        /// <param name="customID">overrides ID via SetID, (see SetID for conditions)</param>
        public Entity(string customID = null) { 
            if (customID != null && SetID(customID))
                return;
            else
                customID = System.Guid.NewGuid().ToString();
        }
        public string ID { get { return id; } }

        /// <summary>
        /// min 8 symbols, leading and trailing whitespace is cut
        /// does not check for duplicate ids
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if id is valid</returns>
        public bool SetID(string id)
        {
            if (id == null)
                return false;
            if (id.Trim().Length < 8)
                return false;

            this.id = id.Trim();
            return true;
        }


        
    }
}
