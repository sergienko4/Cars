using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Model
{
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrachID;

        public string Address{ get; set; }
        public double GeoLocation { get; set; }
        public string BranchName { get; set; }
    }
}