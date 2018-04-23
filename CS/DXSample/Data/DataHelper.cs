using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Xml.Serialization;
using DevExpress.Utils;
using DevExpress.Xpf.Core.Native;
using DXSample.ViewModels;

namespace DXSample.Data {


    [XmlRoot("Employees")]
    public class DataHelper : List<Employee> {

        static readonly List<string> EmployeeDepartmentImages = new List<string> { "administration", "inventory", "manufacturing", "quality", "research", "sales" };
        static ImageSource imageFemaleSrc;
        static ImageSource imageMaleSrc;

        static XmlSerializer Serializer = new XmlSerializer(typeof(DataHelper));

        public static Stream GetDataStream() { return AssemblyHelper.GetResourceStream(typeof(DataHelper).Assembly, "Data/EmployeesWithPhoto.xml", true); }
        public static object GetEmployeeDepartmentImage(string departmentName) {
            var imageName = EmployeeDepartmentImages
                .FirstOrDefault(x => departmentName.ToLower().Contains(x));
            if (string.IsNullOrEmpty(imageName))
                return null;
            return "/DXSample;component/Images/" + imageName + ".png";
        }

        public static List<Employee> GetEmployees() {
            return (List<Employee>)Serializer.Deserialize(GetDataStream());
        }

        public static ImageSource ImageFemale {
            get {
                if (imageFemaleSrc == null)
                    imageFemaleSrc = ImageSourceHelper.GetImageSource(AssemblyHelper.GetResourceUri(typeof(DataHelper).Assembly, "Images/Person_Female.png"));
                return imageFemaleSrc;
            }
        }

        public static ImageSource ImageMale {
            get {
                if (imageMaleSrc == null)
                    imageMaleSrc = ImageSourceHelper.GetImageSource(AssemblyHelper.GetResourceUri(typeof(DataHelper).Assembly, "Images/Person_Male.png"));
                return imageMaleSrc;
            }
        }
    }
}
