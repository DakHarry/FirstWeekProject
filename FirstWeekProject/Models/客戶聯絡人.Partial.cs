using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstWeekProject.Models
{
    [MetadataType(typeof(客戶聯絡人Meta))]
    public partial class 客戶聯絡人
    {
        客戶資料Entities db = new 客戶資料Entities();
    }

    public partial class 客戶聯絡人 : IValidatableObject
    {
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           var data= db.客戶聯絡人.Where(w => w.姓名.Equals(this.姓名)).Where(w => w.Email.Equals(this.Email));
            if(data != null)
            {
                yield return new ValidationResult("該信箱已註冊!",
                new string[] { "Email" });
            }
            //var data = db.客戶聯絡人.Where(w => w.姓名.Equals(this.姓名)).ToList();
            //if (data != null)
            //{
            //    foreach(var i in data.E)
            //    if(this.Email == data.Email.) { 
            //    yield return new ValidationResult("該信箱已註冊!",
            //    new string[] { "Email" });
            //    }
            //}
            yield break;
            //throw new NotImplementedException();
        }
    }


    public partial class 客戶聯絡人Meta
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public int 客戶Id { get; set; }
        [Required]

        public string 職稱 { get; set; }
        [Required]

        public string 姓名 { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{4}-\d{6}$")]
        public string 手機 { get; set; }
        [Required]
        [RegularExpression(@"^\(\d{2}\)\d[0-9]+$")]
        public string 電話 { get; set; }

        public virtual 客戶資料 客戶資料 { get; set; }
    }

}