using Assignment1.Models;

namespace Assignment1
{
    public static class Datastore
    {
        public static List<User> Users { get; set; } = new List<User>()
        {
            new User(1, "Nguyen Van An", "an.nguyen@example.com", "123456", 1, "active"),
            new User(2, "Tran Thi Binh", "binh.tran@example.com", "123456", 2, "locked"),
            new User(3, "Le Van Cuong", "cuong.le@example.com", "123456", 3, "active"),
            new User(4, "Pham Thi Dao", "dao.pham@example.com", "123456", 4, "active"),
            new User(5, "Hoang Minh Duc", "duc.hoang@example.com", "123456", 1, "locked"),
            new User(6, "Nguyen Thi Em", "em.nguyen@example.com", "123456", 2, "active"),
            new User(7, "Bui Van Phuc", "phuc.bui@example.com", "123456", 3, "active"),
            new User(8, "Do Thi Giang", "giang.do@example.com", "123456", 4, "locked"),
            new User(9, "Vo Van Hao", "hao.vo@example.com", "123456", 1, "active"),
            new User(10, "Dang Thi Hoa", "hoa.dang@example.com", "123456", 2, "active"),
            new User(11, "Nguyen Van Hieu", "hieu.nguyen@example.com", "123456", 3, "locked"),
            new User(12, "Tran Thi Huong", "huong.tran@example.com", "123456", 4, "active"),
            new User(13, "Le Van Khanh", "khanh.le@example.com", "123456", 1, "active"),
            new User(14, "Pham Thi Lan", "lan.pham@example.com", "123456", 2, "locked"),
            new User(15, "Hoang Van Long", "long.hoang@example.com", "123456", 3, "active"),
            new User(16, "Nguyen Thi Mai", "mai.nguyen@example.com", "123456", 4, "active"),
            new User(17, "Bui Van Nam", "nam.bui@example.com", "123456", 1, "locked"),
            new User(18, "Do Thi Ngoc", "ngoc.do@example.com", "123456", 2, "active"),
            new User(19, "Vo Van Phat", "phat.vo@example.com", "123456", 3, "active"),
            new User(20, "Dang Thi Quyen", "quyen.dang@example.com", "123456", 4, "locked")
        };



    }
}
