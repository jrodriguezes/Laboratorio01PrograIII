using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class objPet
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Sex { get; set; }
        public int Years { get; set; }
        public bool Status { get; set; }
        public DateTime DateOfEntry { get; set; }
        public byte[] Image { get; set; }  // La imagen se almacena en byte[]


    }
}
