using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSMine.Model
{
    public class Project : NamedRecord
    {
        /// <summary>
        /// Gets or sets project identifier.
        /// </summary>
        /// <value>Project identifier</value>
        public String Identifier { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>Description</value>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets the parent project.
        /// </summary>
        /// <value>Parent project</value>
        public NamedRecord ParentProject { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
