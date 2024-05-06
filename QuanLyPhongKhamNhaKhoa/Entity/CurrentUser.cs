using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKhamNhaKhoa.Entity
{
    public static class CurrentUser
    {
        public static User currentUser { get; set; }
        static CurrentUser()
        {
            string imagePath = "../../image/visible.png";
            byte[] pic = File.ReadAllBytes(imagePath);
            MemoryStream picture;
            picture = new MemoryStream(pic);
            // Khởi tạo một đối tượng User mặc định
            currentUser = new User
            {
                UserID = "userID",
                FullName = "fullName",
                BirthDate = Convert.ToDateTime("06/05/2003"),
                Gender = "gender",
                PersionalID = "persionalID",
                PhoneNumber = "phoneNumber",
                Email = "email",
                Address = "address",
                IsRole = "isRole",
                Password = "password",
                Image = picture
            };


        }
    }
}
