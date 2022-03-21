using CommandLine;
using Pbx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinode.ChatBot.DemoNetCore
{
    internal class Program
    {
        public class CmdOptions
        {
            [Option('C', "login-cookie", Required = false, Default = ".tn-cookie", HelpText = "read credentials from the provided cookie file")]
            public string CookieFile { get; set; }

            [Option('T', "login-token", Required = false, HelpText = "login using token authentication")]
            public string Token { get; set; }

            [Option('B', "login-basic", Required = false, HelpText = "login using basic authentication username:password")]
            public string Basic { get; set; }

            [Option('L', "listen", Required = false, Default = "0.0.0.0:40051", HelpText = "address to listen on for incoming Plugin API calls")]
            public string Listen { get; set; }

            [Option('S', "server", Required = false, Default = "localhost:16060", HelpText = "address of Tinode server gRPC endpoint")]
            public string Host { get; set; }
        }

        /// <summary>
        /// ChatBot auto reply implement
        /// </summary>
        public class BotReponse : IBotResponse
        {
            private ChatBot bot;

            public BotReponse(ChatBot bot)
            {
                this.bot = bot;
            }

            public async Task<ChatMessage> ThinkAndReply(ServerData message)
            {
                foreach (var sub in bot.Subscribers)
                {
                    //Current account friends info
                }
                ChatMessage responseMsg;
                var msgText = message.Content.ToStringUtf8();
                var msg = MsgBuilder.Parse(message);
                string responseText = string.Empty;
                if (msg.IsPlainText)
                {
                    var lstQuestionAnswer = new List<MessageReponse>
                    {
                        new MessageReponse
                        {
                            Key ="Những đối tượng nào có thể tham gia đi xuất khẩu lao động tại Nhật Bản của Công ty",
                            Message = "<p>Là công dân Việt Nam có nguyện vọng đi làm việc tại nước ngoài mà trong độ tuổi Công ty có nhu cầu tuyển dụng (phải đảm bảo đủ 18 tuổi trở lên, Công ty không tuyển những người dưới 18 tuổi tính đủ theo ngày sinh).  "
                            +"<br/>"
                            +"<br/>"
                            +"Không phân biệt vùng miền. giới tính … "
                            +"<br/>"
                            +"<br/>"
                            +"Không phải là các đối tượng đang chịu sự quản lý của pháp luật, không phải là những đối tượng đang thi hành án mà chưa được xóa án tích. Lý lịch phải được xác nhận là đối tượng có nhân thân tốt chấp hành tốt mọi đường lối chính sách của Đảng, Nhà nước"
                            +"</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Độ tuổi bao nhiêu thì có thể đi XKLĐ tại Nhật Bản",
                            Message = "<p>Nhật Bản:  "
                                        +"<br/>"
                                        +"<br/>"
                                        +"Độ tuổi tuyển dụng: từ 19 đến 27 tuổi(đối với LĐ đi Nhật Bản) ngoài ra tùy thuộc vào đơn hàng đặc biệt có thể tuyển dụng độ tuổi cao hơn."
                                        +"< br /> "
                                        +"< br /> "
                                        +"Đối với LĐ Nam: Cao từ 165cm trở lên.Nặng: 55kg trở lên"
                                        +"< br /> "
                                        +"< br /> "
                                        +"Đối với lao động Nữ: Cao từ 150 trở lên, Nặng: 42kg"
                                        +"</ p > "
                        },
                        new MessageReponse
                        {
                            Key ="Chi phí đi XKLĐ tại Nhật Bản là bao nhiêu? Xin cho biết cụ thể các chi phí đó ?",
                            Message = "<p>Chi Phí đi lao động Nhật Bản:  "
                                                +"<br/> "
                                                +"<br/> "
                                    +" Chi phí đi Nhật bản chương trình 03 năm là:   "
                                                +"< br /> "
                                                +"< br /> "
                                    +"Tiền phí xuất cảnh: 3.600 USD "
                                                +"< br /> "
                                                +"< br /> "
                                    +"Tiền Học phí học ngoại ngữ cơ bản là: 5.900.000VNĐ "
                                                +"< br /> "
                                                +"< br /> "
                                    +"Tiền học phí kiến thức cần thiết là: 500.000VNĐ. "
                                               +" < br /> "
                                                +"< br /> "
                                    +"Tiền nộp quỹ HTVLNN: 100.000VNĐ "
                                                +"< br /> "
                                                +"< br /> "
                                    +"(Chi phí trên chưa bao gồm tiền ăn học, học ngoại ngữ nâng cao, khám sức khỏe và làm các thủ tục cá nhân sẽ do người lao động tự chi trả).   "
                                                +"< br /> "
                                                +"< br /> "
                                    +" Chi phí đi Nhật bản chương trình 01 năm là:   "
                                                +"< br /> "
                                                +"< br /> "
                                    +"Tiền phí xuất cảnh: 1.200 USD "
                                                +"< br /> "
                                                +"< br /> "
                                    +"Tiền Học phí học ngoại ngữ cơ bản là: 5.900.000VNĐ "
                                                +"< br /> "
                                                +"< br /> "
                                    +"Tiền học phí kiến thức cần thiết là: 500.000VNĐ. "
                                                +"< br /> "
                                                +"< br /> "
                                    +"Tiền nộp quỹ HTVLNN: 100.000VNĐ "
                                            +"</ p > "
                        },
                        new MessageReponse
                        {
                            Key ="Hiện đi XKLĐ tại Nhật Bản có bao nhiêu ngành nghề được phép đi làm việc tại nước ngoài?",
                            Message = "<p>"
                                     +"<br/>"
                         +"Hiện đi XKLĐ tại Nhật Bản có bao nhiêu ngành nghề được phép đi làm việc tại nước ngoài?"
                                     +"<br/>"
                                     +"<br/>"
                         +"Từ năm 2020 Nhật Bản chính thức nới rộng từ 66 lên 76 ngành nghề được phép tiếp nhận thực tập sinh nước ngoài. Hàng loạt các đơn hàng với những ưu đãi hấp dẫn dành cho người lao động mới được chúng tôi tiếp nhận từ phía đối tác Nhật Bản. Dưới đây, Chúng tôi sẽ tổng hợp tất cả các đơn hàng HOT"
                                     +"<br/>"
                                     +"<br/>"
                         +"Danh sách cụ thể của 76 ngành nghề được phép đưa sang làm việc tại Nhật Bản cụ thể vui lòng xem chi tiết TẠI ĐÂY"
                                     +"<br/>"
                                 +"</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Mức lương, thu nhập khi đi XKLĐ tại Nhật Bản?",
                            Message = "<p>M&#7913;c thu nh&#7853;p b&igrave;nh qu&acirc;n c&#7911;a th&#7921;c t&#7853;p sinh Nh&#7853;t B&#7843;n m&#7897;t th&aacute;ng r&#417;i v&agrave;o kho&#7843;ng&#8239;120.000 - 160.000Y&ecirc;n/th&aacute;ng, ch&#432;a k&#7875; c&aacute;c kho&#7843;n l&agrave;m th&ecirc;m, t&#259;ng ca.  Th&ocirc;ng th&#432;&#7901;ng sau khi tr&#7915; c&aacute;c kho&#7843;n chi ph&iacute; sinh ho&#7841;t v&agrave; t&iacute;nh c&#7843; ti&#7873;n l&agrave;m th&ecirc;m h&agrave;ng th&aacute;ng th&igrave; thu nh&#7853;p th&#7921;c l&#297;nh c&#7911;a c&aacute;c b&#7841;n th&#7921;c t&#7853;p sinh s&#7869; r&#417;i v&agrave;o kho&#7843;ng&#8239;13-17 man (t&#432;&#417;ng &#273;&#432;&#417;ng 28-37 tri&#7879;u VN&#272;).  N&#7871;u chi ti&ecirc;u ti&#7871;t ki&#7879;m h&#7907;p l&yacute; th&igrave; sau 3 n&#259;m ch&#259;m chi l&agrave;m vi&#7879;c v&#7873; n&#432;&#7899;c b&#7841;n c&oacute; th&#7875; ti&#7871;t ki&#7879;m &#273;&#432;&#7907;c t&#7915;&#8239;600.000.000VN&#272; - 800.000.000VN&#272;. &#272;&acirc;y l&agrave; s&#7889; ti&#7873;n kh&ocirc;ng h&#7873; nh&#7887; &#273;&#7875; b&#7841;n c&oacute; th&#7875; l&agrave;m &#259;n, trang tr&#7843;i cu&#7897;c s&#7889;ng.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Những quyền lợi khi đi làm việc tại Nhật Bản ?",
                            Message = "<p>C&aacute;c b&#7841;n s&#7869; &#273;&#432;&#7907;c tham gia &#273;&#7847;y &#273;&#7911; c&aacute;c lo&#7841;i b&#7843;o hi&#7875;m x&atilde; h&#7897;i, b&#7843;o hi&#7875;m y t&#7871;, kh&aacute;m s&#7913;c kh&#7887;e &#273;&#7883;nh k&#7923; theo quy &#273;&#7883;nh c&#7911;a ch&iacute;nh ph&#7911; Nh&#7853;t B&#7843;n.  Khi v&#7873; n&#432;&#7899;c s&#7869; nh&#7853;n l&#7841;i &#273;&#432;&#7907;c ti&#7873;n ho&agrave;n thu&#7871; Nenkin, n&#7871;u b&#7841;n l&agrave;m vi&#7879;c v&#7899;i h&#7907;p &#273;&#7891;ng 3 n&#259;m t&#7841;i Nh&#7853;t B&#7843;n th&igrave; s&#7889; ti&#7873;n ho&agrave;n thu&#7871; n&agrave;y s&#7869; r&#417;i v&agrave;o kho&#7843;ng t&#7915; 60 d&#7871;n 80 tri&#7879;u  Sang Nh&#7853;t l&agrave;m vi&#7879;c ngo&agrave;i vi&#7879;c ki&#7871;m th&ecirc;m thu nh&#7853;p th&igrave; c&aacute;c b&#7841;n s&#7869; &#273;&#432;&#7907;c n&acirc;ng cao tay ngh&#7873;, tr&igrave;nh &#273;&#7897; nghi&#7879;p v&#7909; b&#7843;n th&acirc;n. B&ecirc;n c&#7841;nh &#273;&oacute; sau 3 n&#259;m l&agrave;m vi&#7879;c t&#7841;i Nh&#7853;t b&#7841;n s&#7869; c&oacute; kh&#7843; n&#259;ng ti&#7871;ng Nh&#7853;t v&#7919;ng v&agrave;ng, r&egrave;n luy&#7879;n cho m&igrave;nh &#273;&#432;&#7907;c t&aacute;c phong l&agrave;m vi&#7879;c chuy&ecirc;n nghi&#7879;p v&#7873; n&#432;&#7899;c b&#7841;n c&oacute; nhi&#7873;u c&#417; h&#7897;i l&agrave;m vi&#7879;c t&#7841;i c&aacute;c doanh nghi&#7879;p Nh&#7853;t &#273;ang &#273;&#7847;u t&#432; t&#7841;i Vi&#7879;t Nam ho&#7863;c n&#7871;u kh&#7843; n&#259;ng ti&#7871;ng Nh&#7853;t c&#7911;a b&#7841;n t&#7889;t th&igrave; c&oacute; th&#7875; d&#7841;y h&#7885;c ti&#7871;ng b&#7857;ng vi&#7879;c h&#7885;c th&ecirc;m 1 kh&oacute;a k&#7929; n&#259;ng s&#432; ph&#7841;m trong m&#7897;t v&agrave;i th&aacute;ng.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Thời gian đi làm việc tại Nhật Bản là bao nhiêu lâu?",
                            Message = "<p>Hi&#7879;n t&#7841;i theo quy &#273;&#7883;nh c&#7911;a Nh&#7853;t B&#7843;n v&#7873; th&#7901;i gian l&agrave;m vi&#7879;c &#273;&#7889;i v&#7899;i nh&#7919;ng ng&#432;&#7901;i &#273;i XKL&#272; t&#7841;i Nh&#7853;t B&#7843;n l&agrave;:  Ch&#432;&#417;ng tr&igrave;nh th&#7921;c t&#7853;p sinh k&#7929; n&#259;ng: 03 n&#259;m v&agrave; c&oacute; th&#7875; gia h&#7841;n th&ecirc;m 02 n&#259;m.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Khi muốn tham gia chương trình XKLĐ tại Nhật Bản cần chuẩn bị những gì? ",
                            Message = "<p>- N&#7871;u h&#7891; s&#417; c&#7911;a b&#7841;n &#273;&#7841;t y&ecirc;u c&#7847;u th&igrave; c&aacute;n b&#7897; tuy&#7875;n d&#7909;ng s&#7869; h&#432;&#7899;ng d&#7851;n b&#7841;n l&agrave;m th&#7911; t&#7909;c khai form sau &#273;&oacute; &#273;i kh&aacute;m s&#7913;c kh&#7887;e v&agrave; c&oacute; k&#7871;t qu&#7843; x&aacute;c nh&#7853;n s&#7913;c kh&#7887;e t&#7893;ng th&#7875; &#273;&#7841;t ti&ecirc;u chu&#7849;n &#273;i lao &#273;&#7897;ng v&agrave; l&agrave;m vi&#7879;c t&#7841;i n&#432;&#7899;c ngo&agrave;i.  - N&#7871;u &#273;&#7911; ti&ecirc;u chu&#7849;n s&#7913;c kh&#7887;e c&aacute;c b&#7841;n s&#7869; &#273;&#432;&#7907;c t&#432; v&#7845;n l&#7921;a ch&#7885;n &#273;&#417;n h&agrave;ng r&#7891;i tham gia thi tuy&#7875;n</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Môi trường làm việc tại Nhật Bản có khắc nghiệt không?",
                            Message = "<p>- C&oacute; th&#7875; kh&#7859;ng &#273;&#7883;nh Nh&#7853;t B&#7843;n l&agrave; m&#7897;t trong nh&#7919;ng qu&#7889;c gia c&oacute; m&ocirc;i tr&#432;&#7901;ng l&agrave;m vi&#7879;c th&acirc;n thi&#7879;n v&agrave; &#7893;n &#273;&#7883;nh b&#7853;c nh&#7845;t th&#7871; gi&#7899;i, m&#7897;t tu&#7847;n b&#7841;n s&#7869; l&agrave;m vi&#7879;c 40h, &#273;&#432;&#7907;c ngh&#7881; t&#7889;i &#273;a 2 ng&agrave;y/tu&#7847;n. Th&#7901;i gian n&agrave;y b&#7841;n c&oacute; th&#7875; ngh&#7881; ng&#432;&#7901;i, du l&#7883;ch tham quan Nh&#7853;t B&#7843;n ho&#7863;c l&agrave;m th&ecirc;m &#273;&#7875; ki&#7871;m th&ecirc;m thu nh&#7853;p  - Nhi&#7873;u c&ocirc;ng ty c&ograve;n trang b&#7883; th&ecirc;m v&#259;n ph&ograve;ng ph&#7849;m v&agrave; m&#7901;i th&#7847;y gi&aacute;o v&#7873; d&#7841;y ti&#7871;ng Nh&#7853;t cho th&#7921;c t&#7853;p sinh &#273;&#7875; n&acirc;ng cao kh&#7843; n&#259;ng giao ti&#7871;p ti&#7871;ng Nh&#7853;t  - L&agrave;m th&ecirc;m v&agrave;o nh&#7919;ng ng&agrave;y ngh&#7881;, l&agrave;m ngo&agrave;i gi&#7901;, l&agrave;m trong d&#7883;p l&#7877;, t&#7871;t b&#7841;n s&#7869; nh&acirc;n &#273;&#432;&#7907;c m&#7913;c l&#432;&#417;ng cao h&#417;n t&#7915; 150 - 200 %</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Đã từng đi Tu nghiệp Nhật Bản có đi tiếp được không?",
                            Message = "<p>SDS ch&uacute;ng t&ocirc;i &#273;&atilde; c&oacute; r&#7845;t nhi&#7873;u ng&#432;&#7901;i lao &#273;&#7897;ng g&#7885;i tr&#7921;c ti&#7871;p&#8239;ho&#7863;c g&#7917;i tin nh&#7855;n v&#7873; ch&uacute;ng t&ocirc;i c&acirc;u h&#7887;i n&agrave;y, v&igrave; v&#7853;y ch&uacute;ng t&ocirc;i xin tr&#7843; l&#7901;i c&acirc;u h&#7887;i sau &#273;&#7875; m&#7885;i ng&#432;&#7901;i n&#7855;m r&otilde;:  Theo quy &#273;&#7883;nh c&#7911;a ch&iacute;nh ph&#7911; Nh&#7853;t B&#7843;n th&igrave; h&#7885; ch&#7881; ti&#7871;p nh&#7853;n th&#7921;c t&#7853;p sinh n&#432;&#7899;c ngo&agrave;i sang l&agrave;m vi&#7879;c 1 l&#7847;n duy nh&#7845;t v&#7899;i th&#7901;i h&#7841;n t&#7915; 1 n&#259;m - 3 n&#259;m. Nh&#7919;ng th&#7921;c t&#7853;p sinh &#273;&atilde; sang Nh&#7853;t B&#7843;n Tu nghi&#7879;p m&#7897;t l&#7847;n s&#7869; kh&ocirc;ng &#273;&#432;&#7907;c sang Tu nghi&#7879;p t&#7841;i Nh&#7853;t B&#7843;n m&#7897;t l&#7847;n n&#7919;a v&igrave; v&#7853;y ng&#432;&#7901;i lao &#273;&#7897;ng c&#7847;n t&#7881;nh t&aacute;o v&agrave; n&#7855;m b&#7855;t th&ocirc;ng tin n&agrave;y &#273;&#7875; tr&aacute;nh b&#7883; c&aacute;c c&ocirc;ng ty k&eacute;m uy t&iacute;n l&#7917;a &#273;&#7843;o m&agrave; ti&#7873;n m&#7845;t t&#7853;t mang.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Công ty có những chính sách gì hỗ trợ cho người lao động không?",
                            Message = "<p>Khi lao &#273;&#7897;ng tr&uacute;ng tuy&#7875;n n&#7871;u c&oacute; nhu c&#7847;u c&ocirc;ng ty s&#7869; h&#432;&#7899;ng d&#7851;n l&agrave;m h&#7891; s&#417;, th&#7911; t&#7909;c &#273;&#7875; vay v&#7889;n ng&acirc;n h&agrave;ng, qua &#273;&oacute; gi&uacute;p lao &#273;&#7897;ng c&oacute; &#273;i&#7873;u ki&#7879;n t&#7889;t nh&#7845;t &#273;&#7875; &#273;i vay v&#7889;n. S&#7889; ti&#7873;n vay &#273;&#432;&#7907;c h&#7895; tr&#7907; l&ecirc;n &#273;&#7871;n 80% chi ph&iacute; &#273;i Nh&#7853;t.  - Th&#7911; t&#7909;c vay v&#7889;n ng&acirc;n h&agrave;ng xin xem chi ti&#7871;t T&#7840;I &#272;&Acirc;Y</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Những ai có thể tham gia chương trình?",
                            Message = "<p>Th&#7921;c t&#7853;p sinh k&#7929; n&#259;ng:  - Ch&#432;a t&#7915;ng &#273;i th&#7921;c t&#7853;p sinh, v&agrave; ch&#432;a t&#7915;ng xin t&#432; c&aacute;ch l&#432;u tr&uacute;.  - &#272;&#7911; 18 tu&#7893;i, kh&ocirc;ng c&oacute; ti&#7873;n &aacute;n ti&#7873;n s&#7921;, t&#7889;t nghi&#7879;p THPT tr&#7903; l&ecirc;n, &#273;&#7843;m b&#7843;o s&#7913;c kh&#7887;e theo quy &#273;&#7883;nh.   K&#7929; S&#432;:  - T&#7889;t nghi&#7879;p Cao &#273;&#7859;ng, &#272;&#7841;i h&#7885;c tr&#7903; l&ecirc;n  - Nh&#7919;ng th&#7921;c t&#7853;p sinh &#273;&atilde; ho&agrave;n th&agrave;nh ch&#432;&#417;ng tr&igrave;nh TTSKN m&agrave; kh&ocirc;ng vi ph&#7841;m ph&aacute;p lu&#7853;t c&#7911;a Nh&#7853;t B&#7843;n c&#361;ng c&oacute; th&#7875; tham gia theo ch&#432;&#417;ng tr&igrave;nh k&#7929; s&#432;.   Ch&#432;&#417;ng tr&igrave;nh &#272;&#7863;c &#273;&#7883;nh:  - &#272;&#7889;i v&#7899;i nh&#7919;ng ng&#432;&#7901;i &#273;&atilde; t&#7915;ng tham gia ch&#432;&#417;ng tr&igrave;nh TTSKN s&#7889; 2 (&#273;&atilde; qua 3 n&#259;m l&agrave;m vi&#7879;c).  - Chi ti&#7871;t xem xem chi ti&#7871;t T&#7840;I &#272;&Acirc;Y</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Nếu có tay nghề thì lương có được đảm bảo hơn không? Tiến độ xuất cảnh có nhanh hơn không?",
                            Message = "<p>- Theo quy &#273;&#7883;nh c&aacute;c ch&#432;&#417;ng tr&igrave;nh &#7913;ng tuy&#7875;n TTS th&igrave; l&#432;&#417;ng v&agrave; &#273;i&#7873;u ki&#7879;n l&agrave;m vi&#7879;c c&#7911;a TTS s&#7869; &#273;&#432;&#7907;c &#273;&#7843;m b&#7843;o theo m&#7897;t ti&ecirc;u ch&iacute; c&#417; b&#7843;n d&agrave;nh ri&ecirc;ng cho t&#7845;t c&#7843; c&aacute;c TTS tham gia. T&#7915; n&#259;m th&#7913; 2 v&agrave; th&#7913; 3, nh&#7919;ng TTS c&oacute; tay ngh&#7873; t&#7889;t v&agrave; c&oacute; ti&#7871;n b&#7897; h&#417;n, n&#259;ng su&#7845;t h&#417;n s&#7869; &#273;&#432;&#7907;c &#273;&#7843;m b&#7843;o quy&#7873;n l&#7907;i h&#417;n v&#7873; th&#432;&#7903;ng v&agrave; c&aacute;c ch&#7871; &#273;&#7897; &#273;&atilde;i ng&#7897; h&#7845;p h&#7851;n kh&aacute;c.  - V&#7873; ti&#7871;n &#273;&#7897;, nh&#7919;ng TTS c&oacute; tay ngh&#7873; s&#7869; c&oacute; c&#417; h&#7897;i tham gia nhi&#7873;u &#273;&#7907;t thi tuy&#7875;n h&#417;n so v&#7899;i c&aacute;c TTS kh&ocirc;ng c&oacute; tay ngh&#7873;. Ch&iacute;nh v&igrave; v&#7853;y m&agrave; c&#417; h&#7897;i tr&uacute;ng tuy&#7875;n s&#7869; cao h&#417;n v&agrave; ti&#7871;n &#273;&#7897; xu&#7845;t c&#7843;nh c&#361;ng nhanh h&#417;n.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Trong trường hợp đang làm việc tại Nhật Bản mà Công ty bên Nhật phá sản, hoặc không có việc làm thì người lao động sẽ ra sao?",
                            Message = "<p>-Trong tr&#432;&#7901;ng h&#7907;p C&ocirc;ng ty b&#7883; ph&aacute; s&#7843;n nghi&#7879;p &#273;o&agrave;n s&#7869; ph&#7843;i t&igrave;m cho ng&#432;&#7901;i lao &#273;&#7897;ng m&#7897;t c&ocirc;ng ty ti&#7871;p nh&#7853;n kh&aacute;c c&ugrave;ng ngh&agrave;nh ngh&#7873;.  -Trong tr&#432;&#7901;ng h&#7907;p kh&ocirc;ng c&oacute; vi&#7879;c l&agrave;m th&igrave; ng&#432;&#7901;i lao &#273;&#7897;ng v&#7851;n &#273;&#432;&#7907;c h&#432;&#7903;ng 70% m&#7913;c l&#432;&#417;ng theo quy &#273;&#7883;nh trong h&#7907;p &#273;&#7891;ng.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Có thể chuyển Công ty khác trong thời gian làm việc tại Nhật Bản không?",
                            Message = "<p>N&#7871;u c&ocirc;ng ty, x&iacute; nghi&#7879;p n&#417;i TTS l&agrave;m vi&#7879;c kh&ocirc;ng &#273;&#7843;m b&#7843;o c&aacute;c &#273;i&#7873;u ki&#7879;n nh&#432; h&#7907;p &#273;&#7891;ng, x&#7843;y ra c&aacute;c v&#7845;n &#273;&#7873; b&#7841;o h&agrave;nh, &eacute;p bu&#7897;c ngo&agrave;i quy &#273;&#7883;nh ph&aacute;p lu&#7853;t. Ng&#432;&#7901;i lao &#273;&#7897;ng ho&agrave;n to&agrave;n c&oacute; th&#7875; b&aacute;o l&#7841;i v&#7899;i c&ocirc;ng ty ph&aacute;i c&#7917;, nghi&#7879;p &#273;o&agrave;n Nh&#7853;t B&#7843;n, &#272;&#7841;i s&#7913; qu&aacute;n Vi&#7879;t Nam t&#7841;i Nh&#7853;t v&agrave; c&aacute;c t&#7893; ch&#7913;c qu&#7843;n l&yacute; c&#7845;p nh&agrave; n&#432;&#7899;c c&#7911;a Nh&#7853;t nh&#432; OTIT(ti&#7873;n th&acirc;n l&agrave; JITCO) &#273;&#7875; can thi&#7879;p gi&#7843;i quy&#7871;t.  * Xem th&ecirc;m:&#8239;76 ng&agrave;nh ngh&#7873; c&#7911;a th&#7921;c t&#7853;p sinh theo quy &#273;&#7883;nh c&#7911;a OTIT  - Khi &#273;&oacute;, ng&#432;&#7901;i lao &#273;&#7897;ng c&oacute; quy&#7873;n &#273;&#432;&#7907;c chuy&#7875;n sang c&ocirc;ng ty Nh&#7853;t B&#7843;n kh&aacute;c &#273;&#7875; ti&#7871;p t&#7909;c l&agrave;m vi&#7879;c v&agrave; &#273;&#7875; k&#7883;p th&#7901;i h&#7841;n h&#7907;p &#273;&#7891;ng l&agrave;m vi&#7879;c t&#7841;i Nh&#7853;t.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Đi XKLĐ Nhật Bản ngành nghề nào lương cao ?",
                            Message = "<p>&#272;&#7889;i v&#7899;i tr&igrave;nh &#273;&#7897; v&agrave; kinh nghi&#7879;m nh&#432; b&#7841;n th&igrave; c&#417; h&#7897;i &#273;i Nh&#7853;t l&agrave;m vi&#7879;c l&agrave; r&#7845;t l&#7899;n. Do &#273;a s&#7889; c&aacute;c &#273;&#417;n tuy&#7875;n th&#7921;c t&#7853;p sinh Vi&#7879;t Nam l&agrave;m vi&#7879;c t&#7841;i Nh&#7853;t &#273;&#7873;u l&agrave; lao &#273;&#7897;ng ph&#7893; th&ocirc;ng, n&ecirc;n m&#7913;c l&#432;&#417;ng c&#417; b&#7843;n s&#7869; &#273;&#432;&#7907;c c&aacute;c doanh nghi&#7879;p Nh&#7853;t tr&#7843; theo khung l&#432;&#417;ng c&#7911;a &#273;&#7889;i t&#432;&#7907;ng n&agrave;y.  - B&#7903;i v&#7853;y s&#7869; kh&ocirc;ng c&oacute; s&#7921; ch&ecirc;nh l&#7879;ch qu&aacute; l&#7899;n v&#7873; thu nh&#7853;p gi&#7919;a c&aacute;c ng&agrave;nh ngh&#7873;,thu nh&#7853;p c&#417; b&#7843;n c&#7911;a ng&#432;&#7901;i lao &#273;&#7897;ng s&#7869; dao &#273;&#7897;ng trong kho&#7843;ng&#8239;130.000 y&ecirc;n - 165.000 y&ecirc;n. M&#7913;c l&#432;&#417;ng n&agrave;y s&#7869; c&oacute; s&#7921; kh&aacute;c nhau gi&#7919;a t&#7915;ng khu v&#7921;c, c&agrave;ng l&agrave;m &#7903; trung t&acirc;m th&agrave;nh ph&#7889; l&#7899;n th&igrave; thu nh&#7853;p s&#7869; cao h&#417;n nh&#432;ng ch&#7855;c ch&#7855;n chi ph&iacute; sinh ho&#7841;t m&#7897;t th&aacute;ng s&#7869; &#273;&#7855;t &#273;&#7887; h&#417;n r&#7845;t nhi&#7873;u.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Đi XKLĐ Nhật Bản có được bảo lãnh người thân sang Nhật được không?",
                            Message = "<p>Ng&#432;&#7901;i lao &#273;&#7897;ng l&agrave;m vi&#7879;c t&#7841;i Nh&#7853;t &#273;&#432;&#7907;c ph&eacute;p b&#7843;o l&atilde;nh ng&#432;&#7901;i th&acirc;n &#7903; Vi&#7879;t Nam sang Nh&#7853;t  Theo quy &#273;&#7883;nh Ph&aacute;p lu&#7853;t Nh&#7853;t B&#7843;n th&igrave; ch&#7881; nh&#7919;ng ng&#432;&#7901;i trong gia &#273;&igrave;nh v&#7899;i TTS v&agrave; c&oacute; quan h&#7879; huy&#7871;t th&#7889;ng trong 3 &#273;&#7901;i th&igrave; m&#7899;i &#273;&#432;&#7907;c b&#7843;o l&atilde;nh sang Nh&#7853;t. Ng&#432;&#7901;i Nh&#7853;t c&#361;ng c&oacute; th&#7875; l&agrave;m th&#7911; t&#7909;c b&#7843;o l&atilde;nh &#273;&#432;a ng&#432;&#7901;i th&acirc;n l&agrave; ng&#432;&#7901;i Vi&#7879;t Nam sang Nh&#7853;t.  Tuy nhi&ecirc;n v&#7899;i tr&#432;&#7901;ng h&#7907;p &#273;i lao &#273;&#7897;ng l&agrave;m vi&#7879;c t&#7841;i n&#432;&#7899;c ngo&agrave;i theo h&#7907;p &#273;&#7891;ng l&agrave;m th&#7911; t&#7909;c n&agrave;y l&agrave; r&#7845;t kh&oacute;, c&aacute;c C&ocirc;ng ty h&#7885; s&#7869; kh&ocirc;ng th&#7875; &#273;&#7913;ng ra b&#7843;o l&atilde;nh cho (ngo&#7841;i tr&#7915; 1 s&#7889; tr&#432;&#7901;ng h&#7907;p &#273;&#7863;c bi&#7879;t).</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Các loại bệnh nào không được đi XKLĐ sang Nhật Bản",
                            Message = "<p>C&aacute;c b&#7879;nh ph&#7893; bi&#7871;n hi&#7879;n nay nh&#432; Vi&ecirc;m gan B, HIV, lao ph&#7893;i, giang mai th&igrave; ch&#7855;c ch&#7855;n kh&ocirc;ng &#273;i &#273;&#432;&#7907;c XKL&#272; Nh&#7853;t. Nh&#7919;ng b&#7879;nh kh&aacute;c t&ugrave;y v&agrave;o m&#7913;c &#273;&#7897; n&#7863;ng hay nh&#7865;, c&oacute; th&#7875; ch&#7919;a &#273;&#432;&#7907;c hay kh&ocirc;ng s&#7869; ph&#7909; thu&#7897;c v&agrave;o b&#7879;nh vi&#7879;n ch&#7845;p nh&#7853;n k&#7871;t qu&#7843; s&#7913;c kh&#7887;e c&#7911;a b&#7841;n l&agrave; &quot;&#273;&#7841;t&quot; v&agrave; ph&aacute;t h&agrave;nh form s&#7913;c kh&#7887;e th&igrave; b&#7841;n m&#7899;i &#273;&#432;&#7907;c &#273;i XKL&#272; Nh&#7853;t.  Xin xem chi ti&#7871;t 13 b&#7879;nh c&#7845;m kh&ocirc;ng &#273;&#432;&#7907;c l&agrave;m vi&#7879;c t&#7841;i Nh&#7853;t B&#7843;n T&#7840;I &#272;&Acirc;Y</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Khám sức khỏe đi XKLĐ Nhật Bản ở đâu? chi phí mất bao nhiêu?",
                            Message = "<p>Y&#7871;u t&#7889; s&#7913;c kh&#7887;e l&agrave; y&#7871;u t&#7889; ti&ecirc;n quy&#7871;t quy&#7871;t &#273;&#7883;nh b&#7841;n c&oacute; &#273;&#7911; kh&#7843; n&#259;ng &#273;i l&agrave;m vi&#7879;c t&#7841;i Nh&#7853;t B&#7843;n. Do &#273;&oacute; vi&#7879;c kh&aacute;m s&#7913;c kh&#7887;e l&agrave; &#273;i&#7873;u ki&#7879;n b&#7855;t bu&#7897;c n&#7871;u b&#7841;n c&oacute; d&#7921; &#273;&#7883;nh &#273;i XKL&#272; Nh&#7853;t. B&#7841;n c&oacute; th&#7875; th&#259;m kh&aacute;m s&#7913;c kh&#7887;e t&#7841;i 76 b&#7879;nh vi&#7879;n &#273;&#7911; ti&ecirc;u chu&#7849;n kh&aacute;m s&#7913;c kh&#7887;e &#273;i XKL&#272; Nh&#7853;t, xem chi ti&#7871;t th&ocirc;ng tin v&agrave; &#273;&#7883;a ch&#7881; c&#7911;a 76 b&#7879;nh vi&#7879;n n&agrave;y&#8239;T&#7840;I &#272;&Acirc;Y!  Chi ph&iacute; kh&aacute;m v&agrave; ch&#7913;ng nh&#7853;n s&#7913;c kho&#7867; cho ng&#432;&#7901;i &#273;i xu&#7845;t kh&#7849;u lao &#273;&#7897;ng bao g&#7891;m: Chi ph&iacute; kh&aacute;m l&acirc;m s&agrave;ng, x&eacute;t nghi&#7879;m c&#7853;n l&acirc;m s&agrave;ng, ch&#7849;n &#273;o&aacute;n h&igrave;nh &#7843;nh v&agrave; c&aacute;c chi ph&iacute; h&agrave;nh ch&iacute;nh kh&aacute;c. Chi ti&#7871;t v&#7873; chi ph&iacute; kh&aacute;m s&#7913;c kh&#7887;e t&#7841;i b&#7879;nh vi&#7879;n Tr&agrave;ng An l&agrave; 690.000VN&#272;&#8239;l&agrave; kh&aacute;m th&#432;&#7901;ng, 740.000VN&#272; l&agrave; kh&aacute;m nhanh.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Quy trình tham gia chương trình XKLĐ Nhật Bản tại Công ty như thế nào?  ",
                            Message = "<p>Quy tr&igrave;nh chung m&agrave; t&#7845;t c&#7843; c&aacute;c &#7913;ng vi&ecirc;n khi tham gia ch&#432;&#417;ng tr&igrave;nh XKLD Nh&#7853;t B&#7843;n t&#7841;i c&ocirc;ng ty ph&#7843;i th&#7921;c hi&#7879;n qua c&aacute;c b&#432;&#7899;c sau:  B&#432;&#7899;c 1:&#8239;Li&ecirc;n h&#7879; c&aacute;n b&#7897; t&#432; v&#7845;n tuy&#7875;n d&#7909;ng&#8239;:&#8239;&#273;&#7875; &#273;&#7863;t l&#7883;ch h&#7865;n ho&#7863;c t&#432; v&#7845;n &#273;&#417;n h&agrave;ng ph&ugrave; h&#7907;p, h&#432;&#7899;ng d&#7851;n l&agrave;m c&aacute;c th&#7911; t&#7909;c ho&#7863;c h&#7891; s&#417; c&#7847;n thi&#7871;t  B&#432;&#7899;c 2:&#8239;N&#7897;p h&#7891; s&#417;&#8239;( n&#7871;u &#273;&#417;n h&agrave;ng c&#7847;n h&#7885;c ngu&#7891;n, c&ograve;n kh&ocirc;ng th&igrave; ch&#7881; l&agrave;m h&#7891; s&#417; sau thi &#273;&#7895; &#273;&#417;n h&agrave;ng), khai form th&ocirc;ng tin l&agrave;m c&aacute;c th&#7911; t&#7909;c check ki&#7875;m so&aacute;t, &#273;&#7889;i ngo&#7841;i&#8239;v&agrave; kh&aacute;m s&#7913;c kh&#7887;e, ti&#7873;n c&#7917; v&agrave;o &#273;&#417;n h&agrave;ng ph&ugrave; h&#7907;p => ch&#7901; ng&agrave;y thi tuy&#7875;n c&#7911;a &#273;&#417;n h&agrave;ng&#8239;(Thi tuy&#7875;n/ Ph&#7887;ng v&#7845;n tr&#7921;c ti&#7871;p v&#7899;i nghi&#7879;p &#273;o&agrave;n, doanh nghi&#7879;p Nh&#7853;t B&#7843;n)  B&#432;&#7899;c 3:&#8239;&#272;&agrave;o t&#7841;o, &#273;&#7883;nh h&#432;&#7899;ng l&agrave;m vi&#7879;c Nh&#7853;t B&#7843;n cho TTS. Th&#432;c t&#7853;p sinh sau khi ch&uacute;ng tuy&#7875;n &#273;&#417;n h&agrave;ng s&#7869; &#273;&#432;&#7907;c CB ph&#7909; tr&aacute;ch h&#432;&#7899;ng d&#7851;n l&agrave;m c&aacute;c th&#7911; t&#7909;c nh&#7853;p h&#7885;c v&agrave; &#273;&agrave;o t&#7841;o t&#7841;i c&aacute;c trung t&acirc;m c&#7911;a C&ocirc;ng ty (Trung t&acirc;m s&#7869; &#273;&#7841;o t&#7841;o cho TTS v&#7873; ti&#7871;ng Nh&#7853;t, tay ngh&#7873; n&acirc;ng cao, l&#7889;i s&#7889;ng v&#259;n h&oacute;a c&#7911;a ng&#432;&#7901;i Nh&#7853;t,...)  Chi ti&#7871;t xem c&aacute;c h&igrave;nh &#7843;nh c&#7911;a Tr&#432;&#7901;ng &#272;&agrave;o t&#7841;o vui l&ograve;ng xem&#8239; &#7903; &#273;&acirc;y&#8239;(Fanpege )  B&#432;&#7899;c 4:&#8239;Xin Visa/th&#7883; th&#7921;c Nh&#7853;t B&#7843;n, &#273;&#7863;t v&eacute; v&agrave; ho&agrave;n th&agrave;nh t&agrave;i ch&iacute;nh -&#8239;xu&#7845;t c&#7843;nh (C&aacute;c thu t&#7909;c C&ocirc;ng ty s&#7869; lo, TTS ch&#7881; lo ho&agrave;n t&#7845;t t&agrave;i ch&iacute;nh theo quy &#273;&#7883;nh c&#7911;a c&ocirc;ng ty). V&agrave; khi nh&#7853;p&#8239;c&#7843;nh t&#7841;i&#8239;Nh&#7853;t B&#7843;n th&igrave; TTS s&#7869; &#273;&#432;&#7907;c &#273;&agrave;o t&#7841;o &#273;&#7875; c&oacute; th&#7875; th&iacute;ch nghi v&#7899;i m&ocirc;i tr&#432;&#7901;ng v&agrave; cu&#7897;c s&#7889;ng Nh&#7853;t B&#7843;n (&#272;&agrave;o t&#7841;o n&agrave;y C&ocirc;ng ty s&#7869; lo cho TTS, th&#7901;i gian &#273;&agrave;o t&#7841;o kho&#7843;ng 30 ng&agrave;y v&agrave; c&oacute; ti&#7873;n h&#7895; tr&#7907; &#273;&agrave;o t&#7841;o)</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Đi XKLĐ tại Nhật Bản có phải đóng tiền chống chốn không?",
                            Message = "<p>T&#7841;i th&#7901;i &#273;i&#7875;m tr&#432;&#7899;c n&#259;m 2016 th&igrave; b&#7855;t bu&#7897;c ph&#7843;i c&oacute; ti&#7873;n th&#7871; ch&#7845;p ch&#7889;ng tr&#7889;n.  T&#7841;i th&#7901;i &#273;i&#7875;m hi&#7879;n t&#7841;i, th&#7921;c hi&#7879;n theo &#273;&uacute;ng th&#7887;a thu&#7853;n c&#7911;a hai nh&agrave; n&#432;&#7899;c Vi&#7879;t Nam v&agrave; Nh&#7853;t B&#7843;n v&agrave; v&#259;n b&#7843;n h&#432;&#7899;ng d&#7851;n s&#7889; 1123/CV-C&#7909;c qu&#7843;n l&yacute; lao &#273;&#7897;ng ngo&agrave;i n&#432;&#7899;c v&#7873; vi&#7879;c quy &#273;&#7883;nh c&aacute;c chi ph&iacute; &#273;&#7875; tham gia ch&#432;&#417;ng tr&igrave;nh XKL&#272; Nh&#7853;t B&#7843;n th&igrave; ng&#432;&#7901;i lao &#273;&#7897;ng kh&ocirc;ng ph&#7843;i n&#7897;p ti&#7873;n ch&#7889;ng tr&#7889;n.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Nếu đi XKLĐ tại Nhật Bản mắt cận bao nhiêu thì không đi được Nhật Bản",
                            Message = "<p>Theo quy &#273;&#7883;nh th&#7883; l&#7921;c l&agrave; y&#7871;u t&#7889; r&#7845;t quan tr&#7885;ng khi ng&#432;&#7901;i lao &#273;&#7897;ng c&oacute; &#273;&#7883;nh h&#432;&#7899;ng &#273;i XKL&#272; Nh&#7853;t B&#7843;n. Do ch&#432;&#417;ng tr&igrave;nh XKL&#272; Nh&#7853;t B&#7843;n khi tham gia ph&#7843;i tr&#7921;c ti&#7871;p ph&#7887;ng v&#7845;n v&#7899;i nh&agrave; m&aacute;y x&iacute; nghi&#7879;p, do &#273;&oacute; ph&#7843;i c&#7841;nh tranh theo t&#7927; l&#7879; th&ocirc;ng th&#432;&#7901;ng 1 ch&#7885;i 2 ho&#7863;c 3. N&ecirc;n r&otilde; r&agrave;ng th&#7883; l&#7921;c k&eacute;m l&agrave; b&#7845;t l&#7907;i kh&ocirc;ng h&#7873; nh&#7887;. Ch&#432;a k&#7875; &#273;&#7871;n nhi&#7873;u c&ocirc;ng vi&#7879;c y&ecirc;u c&#7847;u th&#7883; l&#7921;c t&#7889;t nh&#432; x&acirc;y d&#7921;ng, &#273;i&#7879;n t&#7917;, d&#7879;t may&#8230;  Y&ecirc;u c&#7847;u th&#7883; l&#7921;c &#273;i XKL&#272; Nh&#7853;t B&#7843;n:  Th&#7883; l&#7921;c 8/10 tr&#7903; l&ecirc;n: Th&#432;&#7901;ng v&agrave;o c&aacute;c &#273;&#417;n h&agrave;ng l&#7855;p r&aacute;p linh ki&#7879;n &#273;i&#7879;n t&#7917;, x&acirc;y d&#7921;ng, may m&#7863;c&#8230;  Th&#7883; l&#7921;c 6/10 tr&#7903; l&ecirc;n: M&#7863;t b&#7857;ng chung c&aacute;c ngh&agrave;nh ngh&#7873; th&igrave; th&#7883; l&#7921;c 6/10 ho&agrave;n to&agrave;n c&oacute; th&#7875; tham gia b&igrave;nh th&#432;&#7901;ng.  Th&#7883; l&#7921;c 4/10 tr&#7903; l&ecirc;n: M&#7897;t s&#7889; ngh&agrave;nh ngh&#7873; kh&ocirc;ng y&ecirc;u c&#7847;u cao v&#7873; th&#7883; l&#7921;c nh&#432; n&ocirc;ng nghi&#7879;p, bao b&igrave;, th&#7921;c ph&#7849;m&#8230;</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Độ tuổi nào thì phù hợp nhất để đi XKLĐ Nhật Bản?",
                            Message = "<p>C&aacute;c c&ocirc;ng ty Nh&#7853;t B&#7843;n ti&#7871;p nh&#7853;n lao &#273;&#7897;ng t&iacute;nh theo tu&#7893;i d&#432;&#417;ng, c&aacute;c b&#7841;n tr&#7867; v&#7915;a t&#7889;t nghi&#7879;p c&#7845;p 3 l&agrave; v&#7915;a tr&ograve;n 18 tu&#7893;i. Nam gi&#7899;i 18-19 tu&#7893;i th&#432;&#7901;ng l&agrave; kh&oacute; &#273;i, N&#7919; th&igrave; d&#7877;, do c&ocirc;ng vi&#7879;c c&#7911;a N&#7919; &#273;&#417;n gi&#7843;n v&agrave; h&#7885; c&#361;ng th&iacute;ch &#273;&#7897; tu&#7893;i tr&#7867;.  Ngo&agrave;i ra c&#361;ng c&oacute; m&#7897;t s&#7889; c&aacute;c &#273;&#417;n h&agrave;ng h&#7885; y&ecirc;u c&#7847;u gi&#7899;i h&#7841;n v&#7873; tu&#7893;i th&igrave; c&oacute; th&#7875; l&#7845;y &#273;&#7871;n 38 tu&#7893;i.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Học chuyên ngành kinh tế (các ngành khác) nên đi XKLĐ Nhật Bản không?",
                            Message = "<p>Vi&#7879;c quy&#7871;t &#273;&#7883;nh &#273;i TTSKN Nh&#7853;t B&#7843;n s&#7869; l&agrave; c&#417; h&#7897;i t&#7889;t cho nh&#7919;ng sinh vi&ecirc;n tr&#7867; m&#7899;i ra tr&#432;&#7901;ng c&oacute; th&#7875; h&#7885;c h&#7887;i t&aacute;c phong l&agrave;m vi&#7879;c, n&acirc;ng cao tay ngh&#7873;, kh&aacute;m ph&aacute; v&#259;n h&oacute;a Nh&#7853;t B&#7843;n c&#361;ng nh&#432; t&iacute;ch l&#361;y v&#7889;n v&agrave; x&acirc;y d&#7921;ng t&#432;&#417;ng lai v&#7919;ng tr&#7855;c h&#417;n. V&#7853;y &#273;&#7889;i t&#432;&#7907;ng h&#7885;c Cao &#273;&#7859;ng, &#272;&#7841;i h&#7885;c ngh&agrave;nh kinh t&#7871; c&#361;ng n&ecirc;n tham gia.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Có nên nghỉ học cao đẳng, đại học để đi XKLĐ Nhật Bản không ? ",
                            Message = "<p>R&#7845;t nhi&#7873;u sinh vi&ecirc;n n&#259;m th&#7913; nh&#7845;t, n&#259;m th&#7913; hai b&#7883; r&#417;i v&agrave;o t&igrave;nh tr&#7841;ng ch&aacute;n h&#7885;c. M&agrave; nguy&ecirc;n nh&acirc;n l&agrave; ch&#432;a th&iacute;ch nghi &#273;&#432;&#7907;c v&#7899;i ph&#432;&#417;ng ph&aacute;p h&#7885;c t&#7853;p m&#7899;i, c&aacute;ch ti&#7871;p c&#7853;n ki&#7871;n th&#7913;c &#7903; &#272;&#7841;i h&#7885;c ho&agrave;n to&agrave;n kh&aacute;c so v&#7899;i khi h&#7885;c c&#7845;p 3. Vi&#7879;c thay &#273;&#7893;i &#273;&#7875; th&iacute;ch nghi v&#7899;i c&aacute;i m&#7899;i lu&ocirc;n l&agrave; th&#7917; th&aacute;ch v&#7899;i con ng&#432;&#7901;i v&#7889;n &#273;&atilde; quen v&#7899;i th&oacute;i quen c&#361;.  Do &#273;&oacute; b&#7841;n t&#7921; xem x&eacute;t v&agrave;o b&#7843;n th&acirc;n &#273;&#7875; &#273;&#432;a ra s&#7921; l&#7921;a ch&#7885;n c&#7911;a m&igrave;nh sao cho ph&ugrave; h&#7907;p v&#7899;i t&igrave;nh tr&#7841;ng c&#7911;a b&#7843;n th&acirc;n (khuy&#7871;n c&aacute;o ch&uacute;ng t&ocirc;i kh&ocirc;ng s&uacute;i d&#7909;c c&aacute;c b&#7841;n b&#7887; h&#7885;c.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Giải đáp thắc mắc về tiền làm thêm và tăng ca tại Nhật Bản  ",
                            Message = "<p>T&acirc;m l&yacute; chung c&#7911;a r&#7845;t nhi&#7873;u ng&#432;&#7901;i khi &#273;i XKL&#272; Nh&#7853;t B&#7843;n &#273;&#7873;u mong mu&#7889;n &#273;&#432;&#7907;c l&agrave;m vi&#7879;c &#7903; m&#7897;t c&ocirc;ng ty v&#7899;i m&ocirc;i tr&#432;&#7901;ng l&agrave;m vi&#7879;c t&#7889;t, thu nh&#7853;p cao&#8230;Tuy nhi&ecirc;n ch&uacute;ng t&ocirc;i th&#7845;y r&#7845;t nhi&#7873;u ng&#432;&#7901;i &#273;&ograve;i h&#7887;i r&#7857;ng:&rdquo;C&ocirc;ng ty ph&#7843;i &#273;&#7843;m b&#7843;o s&#7889; gi&#7901; t&#259;ng ca th&#7853;t nhi&#7873;u&rdquo;, &ldquo;Ph&#7843;i &#273;&#7843;m b&#7843;o s&#7889; gi&#7901; t&#259;ng ca t&#7889;i thi&#7875;u l&agrave;..&rdquo;  &#272;&#7889;i v&#7899;i ch&#432;&#417;ng tr&igrave;nh Nh&#7853;t B&#7843;n th&igrave; h&#7885; c&oacute; quy &#273;&#7883;nh m&#7913;c ti&#7873;n l&#432;&#417;ng l&agrave;m th&ecirc;m v&agrave; gi&#7901; t&#259;ng ca &#273;&#7889;i v&#7899;i t&#7915;ng v&ugrave;ng mi&#7873;n c&#7911;a Nh&#7853;t B&#7843;n c&#7909; th&#7875; chi ti&#7871;t m&#7901;i xem T&#7840;I &#272;&Acirc;Y</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Cần chuẩn bị gì trước khi lên đường đi XKLĐ tại Nhật Bản?",
                            Message = "<p>T&#7845;t c&#7843; nh&#7919;ng ng&#432;&#7901;i lao &#273;&#7897;ng chu&#7849;n b&#7883; sang l&agrave;m vi&#7879;c t&#7841;i Nh&#7853;t B&#7843;n ph&#7843;i &#273;&#432;&#7907;c trang b&#7883; nh&#7919;ng ki&#7871;n th&#7913;c sau:  &#272;&#432;&#7907;c trang b&#7883; v&#7889;n ti&#7871;ng Nh&#7853;t ph&#7843;i &#273;&#7841;t &#273;&#432;&#7907;c &#7903; m&#7913;c t&#432;&#417;ng &#273;&#432;&#417;ng N4.  &#272;&#432;&#7907;c trang b&#7883; nh&#7919;ng ki&#7871;n th&#7913;c c&#7847;n thi&#7871;t nh&#432; c&aacute;c quy &#273;&#7883;nh, l&#7877; nghi, v&#259;n h&oacute;a, phong t&#7909;c, ph&aacute;p lu&#7853;t c&#7911;a Nh&#7853;t B&#7843;n v&agrave; nh&agrave; m&aacute;y n&#417;i &#273;&#7871;n l&agrave;m vi&#7879;c.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Làm việc tại Nhật Bản được nghỉ những ngày nào trong năm?",
                            Message = "Theo quy định của Nhật Bản thì người lao động có thể được nghỉ khoảng hơn 100 ngày trong năm. Như nghỉ tết dương lịch, nghỉ ngày lịch đỏ, nghỉ tuần lễ vàng, nghỉ tuần lễ obon…."
                        },
                        new MessageReponse
                        {
                            Key ="Đã từng đi du học sinh có được tham gia chương trình thực tập sinh kỹ năng không?",
                            Message = "<p>Theo quy &#273;&#7883;nh c&#7911;a Ch&iacute;nh ph&#7911; Nh&#7853;t B&#7843;n ch&#432;&#417;ng tr&igrave;nh TTSKN Nh&#7853;t B&#7843;n (tr&#432;&#7899;c &#273;&oacute; c&ograve;n g&#7885;i l&agrave; TNS Nh&#7853;t B&#7843;n c&oacute; c&#7845;p &#273;&#7897; th&#7845;p h&#417;n so v&#7899;i di&#7879;n du h&#7885;c sinh Nh&#7853;t B&#7843;n. Do &#273;&oacute; n&#7871;u &#273;&atilde; t&#7915;ng xin t&#432; c&aacute;ch l&#432;u tr&uacute; l&agrave; du h&#7885;c sinh th&igrave; s&#7869; kh&ocirc;ng &#273;&#432;&#7907;c x&eacute;t duy&#7879;t &#273;&#7875; tham gia ti&#7871;p ch&#432;&#417;ng tr&igrave;nh TTSKN Nh&#7853;t B&#7843;n n&#7919;a. N&#7871;u mu&#7889;n sang Nh&#7853;t B&#7843;n &#7903; tr&#432;&#7901;ng h&#7907;p n&agrave;y th&igrave; ph&#7843;i tham gia &#7903; di&#7879;n cao h&#417;n nh&#432; Cao h&#7885;c&#8230;</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Học cấp 2 có đi được XKLĐ Nhật Bản không?",
                            Message = "<p>Hi&#7879;n nay t&#7841;i Vi&#7879;t Nam v&#7845;n &#273;&#7873; ph&#7893; c&#7853;p gi&aacute;o d&#7909;c &#273;&atilde; &#273;&#432;&#7907;c tri&#7875;n khai &#273;&#7871;n kh&#7855;p c&aacute;c v&ugrave;ng mi&#7873;n tr&ecirc;n &#273;&#7845;t n&#432;&#7899;c. Tuy nhi&ecirc;n, v&#7851;n c&ograve;n 20% l&#7921;c l&#432;&#7907;ng lao &#273;&#7897;ng m&#7899;i t&#7889;t nghi&#7879;p c&#7845;p 2 ch&#432;a t&#7889;t nghi&#7879;p c&#7845;p 3.  V&#7853;y &#273;&#7889;i v&#7899;i nh&#7919;ng b&#7841;n ch&#7881; t&#7889;t nhi&#7879;p c&#7845;p 2 c&oacute; c&#417; h&#7897;i &#273;&#7875; &#273;i XKL&#272; Nh&#7853;t B&#7843;n &#273;&#432;&#7907;c kh&ocirc;ng? &#272;&acirc;y &#273;ang l&agrave; ch&#7911; &#273;&#7873; &#273;&#432;&#7907;c nhi&#7873;u b&#7841;n tr&#7867; c&oacute; mong mu&#7889;n &#273;i l&agrave;m vi&#7879;c t&#7841;i Nh&#7853;t B&#7843;n quan t&acirc;m, t&igrave;m hi&#7875;u v&agrave; &#273;&#432;&#7907;c gi&#7843;i &#273;&aacute;p c&#7909; th&#7875;:  + Quy &#273;&#7883;nh kh&ocirc;ng cho ph&eacute;p ng&#432;&#7901;i ch&#432;a t&#7889;t nghi&#7879;p c&#7845;p 3 &#273;&#432;&#7907;c tham gia ch&#432;&#417;ng tr&igrave;nh &#273;i TTSKN t&#7841;i Nh&#7853;t B&#7843;n.  + Nh&#432;ng &#7903; th&#7901;i &#273;i&#7875;m hi&#7879;n t&#7841;i do nhu c&#7847;u c&#7847;n ti&#7871;p nh&#7853;n ng&#432;&#7901;i lao &#273;&#7897;ng sang Nh&#7853;t B&#7843;n l&agrave;m vi&#7879;c nhi&#7873;u n&ecirc;n m&#7897;t s&#7889; c&ocirc;ng ty tuy&#7875;n d&#7909;ng kh&ocirc;ng &#273;&#7873; c&#7853;p &#273;&#7871;n tr&igrave;nh &#273;&#7897; v&#259;n h&oacute;a hay y&ecirc;u c&#7847;u ph&#7843;i t&#7889;t nghi&#7879;p ph&#7843;i t&#7889;t nghi&#7879;p c&#7845;p 3. Do &#273;&oacute; c&aacute;c b&#7841;n v&#7851;n c&oacute; c&#417; h&#7897;i &#273;&#7875; tham gia.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Từng bị và có tiền án có đi XKLĐ Nhật Bản được khổng?",
                            Message = "<p>&#272;&#7889;i v&#7899;i ng&#432;&#7901;i &#273;&atilde; t&#7915;ng b&#7883; t&ograve;a &aacute;n tuy&ecirc;n &aacute;n t&ugrave; treo v&igrave; t&#7897;i c&#7889; &yacute; g&acirc;y th&#432;&#417;ng t&iacute;ch. Hi&#7879;n t&#7841;i &#273;&atilde; ho&agrave;n th&agrave;nh b&#7843;n &aacute;n v&agrave; &#273;&oacute;ng &#273;&#7847;y &#273;&#7911; c&aacute;c kho&#7843;n &aacute;n ph&iacute;. T&#7915; &#273;&oacute; &#273;&#7871;n nay kh&ocirc;ng vi ph&#7841;m b&#7845;t k&#7923; t&#7897;i g&igrave; m&agrave; &#273;&#432;&#7907;c to&agrave;n &aacute;n c&oacute; quy&#7871;t &#273;&#7883;nh &#273;&#7891;ng &yacute; x&oacute;a &aacute;n t&iacute;ch, mong mu&#7889;n &#273;&#259;ng k&yacute; &#273;i lao &#273;&#7897;ng t&#7841;i Nh&#7853;t B&#7843;n &#273;&#7875; trang tr&#7843;i cu&#7897;c s&#7889;ng v&agrave; ho&agrave;n l&#432;&#417;ng th&igrave; c&ocirc;ng ty s&#7869; xem x&eacute;t. C&#259;n c&#7913; v&agrave;o l&yacute; l&#7883;ch t&#432; ph&aacute;p c&#7911;a ng&#432;&#7901;i lao &#273;&#7897;ng &#273;&#432;&#7907;c s&#7903; t&#432; ph&aacute;p &#273;&#7883;a ph&#432;&#417;ng c&#7845;p v&agrave; s&#7921; ch&#7845;p thu&#7853;n c&#7911;a c&ocirc;ng ty tuy&#7875;n d&#7909;ng th&igrave; m&#7899;i &#273;&#432;&#7907;c s&#7855;p x&#7871;p v&agrave;o tham gia ch&#432;&#417;ng tr&igrave;nh.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Dệt, may là ngành đi XKLĐ Nhật Bản với mức phí thấp nhất và dễ đi nhất đúng không?",
                            Message = "<p>&#272;&#7863;c th&ugrave; c&#7911;a &#273;&#417;n tuy&#7875;n ng&agrave;nh D&#7879;t, may l&agrave; &#7913;ng vi&ecirc;n s&#7869; tham gia ph&#7887;ng v&#7845;n n&#7871;u &#273;&#7911; &#273;i&#7873;u ki&#7879;n tr&uacute;ng tuy&#7875;n s&#7869; &#273;&#432;&#7907;c &#273;&agrave;o t&#7841;o ti&#7871;ng Nh&#7853;t v&agrave; r&egrave;n luy&#7879;n n&acirc;ng cao tay ngh&#7873;, m&#7897;t s&#7889; &#273;&#417;n h&agrave;ng s&#7869; y&ecirc;u c&#7847;u kinh nghi&#7879;m may l&acirc;u n&#259;m, may ho&agrave;n thi&#7879;n s&#7843;n ph&#7849;m ho&#7863;c may th&#7901;i trang. Th&igrave; &#273;&#7889;i v&#7899;i c&ocirc;ng ty SDS kh&ocirc;ng c&oacute; chuy&#7879;n m&#7913;c ph&iacute; th&#7845;p. C&ocirc;ng ty SDS ch&#7881; &aacute;p d&#7909;ng duy nh&#7845;t m&#7913;c ph&iacute; theo quy &#273;&#7883;nh c&#7911;a BL&#272; Vi&#7879;t Nam v&agrave; Ch&iacute;nh ph&#7911; Nh&#7853;t B&#7843;n &#273;&atilde; th&#7889;ng nh&#7845;t. Tuy nhi&ecirc;n &#273;&#7889;i v&#7899;i ng&#432;&#7901;i lao &#273;&#7897;ng c&oacute; tay ngh&#7873; th&igrave; thi tuy&#7875;n s&#7869; d&#7877; d&agrave;ng v&agrave; thu&#7853;n l&#7907;i h&#417;n.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Xin cho hỏi thông tin về lương, BHXH, phụ cấp khi đi XKLĐ Nhật Bản?",
                            Message = "<p>Nh&#7919;ng n&#259;m g&#7847;n &#273;&acirc;y l&#432;&#7907;ng ng&#432;&#7901;i lao &#273;&#7897;ng sang l&agrave;m vi&#7879;c v&agrave; h&#7885;c t&#7853;p t&#7841;i Nh&#7853;t B&#7843;n t&#259;ng m&#7841;nh, b&#7903;i &#273;&acirc;y l&agrave; th&#7883; tr&#432;&#7901;ng lao &#273;&#7897;ng ti&#7873;m n&#259;ng v&#7899;i m&#7913;c l&#432;&#417;ng cao c&ugrave;ng nh&#7919;ng ch&#7871; &#273;&#7897; b&#7843;o hi&#7875;m, ph&#7909; c&#7845;p kh&aacute; t&#7889;t n&ecirc;n n&#7871;u b&#7841;n &#273;ang c&oacute; &yacute; &#273;&#7883;nh ch&#7885;n &#273;i XKL&#272; Nh&#7853;t B&#7843;n l&agrave; &ldquo;B&#7871;n &#273;&#7895;&rdquo; cho con &#273;&#432;&#7901;ng tu nghi&#7879;p v&agrave; h&#7885;c h&#7887;i, ph&aacute;t tri&#7875;n kinh t&#7871; c&#7911;a m&igrave;nh th&igrave; &#273;&#7889;i v&#7899;i Nh&#7853;t B&#7843;n h&#7885; c&oacute; quy &#273;&#7883;nh v&#7873; m&#7913;c l&#432;&#417;ng, b&#7843;o hi&#7875;m v&agrave; ph&#7909; c&#7845;p xin xem chi ti&#7871;t T&#7840;I &#272;&Acirc;Y</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Tối thiểu mỗi giờ làm việc tại Nhật Bản người lao động nhận được bao nhiêu?",
                            Message = "<p>&#272;&#7889;i v&#7899;i ng&#432;&#7901;i lao &#273;&#7897;ng c&oacute; nguy&#7879;n v&#7885;ng &#273;i XKL&#272; t&#7841;i Nh&#7853;t B&#7843;n th&igrave; m&#7909;c &#273;&iacute;ch &#273;&#7847;u ti&ecirc;n v&agrave; tr&ecirc;n h&#7871;t l&agrave; m&#7913;c thu nh&#7853;p ki&#7871;m &#273;&#432;&#7907;c m&#7895;i gi&#7901;, m&#7895;i ng&agrave;y, m&#7895;i th&aacute;ng l&agrave; bao nhi&ecirc;u? Sau 3 n&#259;m c&oacute; th&#7875; t&iacute;ch l&#361;y &#273;&#432;&#7907;c bao nhi&ecirc;u khi v&#7873; n&#432;&#7899;c? Tuy v&#7853;y l&#7841;i r&#7845;t &iacute;t ng&#432;&#7901;i hi&#7875;u r&otilde; &#273;&#432;&#7907;c l&agrave; m&igrave;nh &#273;&#432;&#7907;c nh&agrave; m&aacute;y tr&#7843; bao nhi&ecirc;u?  &#272;&#7889;i v&#7899;i vi&#7879;c n&agrave;y th&igrave; Nh&#7853;t B&#7843;n c&oacute; quy &#273;&#7883;nh v&#7873; m&#7913;c l&#432;&#417;ng l&agrave;m theo gi&#7901;, ng&agrave;y t&#7841;i t&#7915;ng v&ugrave;ng mi&#7873;n xin xem chi ti&#7871;t T&#7840;I &#272;&Acirc;Y  Th&ocirc;ng th&#432;&#7901;ng l&#432;&#417;ng c&#417; b&#7843;n &#273;&#432;&#7907;c t&iacute;nh kho&#7843;ng 890 y&ecirc;n/gi&#7901;.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Từng bị gẫy tay, gẫy chân có đi XKLĐ Nhật Bản được không?",
                            Message = "Đối với các tiêu trí cho từng đơn hàng tuyển chọn lao động Nhật Bản do công ty nhà máy xí nghiệp đưa ra. Nhưng do trước đây người lao động đã từng bị gãy tay, gãy chân mà đã được nắn chỉnh lại sức khỏe đã hồi phục hoàn toàn và có thể làm được việc nặng. Thì việc này sẽ căn cứ vào kết quả khám sức khỏe của Bệnh viện được Bộ Y tế Việt Nam đồng ý khám và cho kết quả đủ điều kiện đảm bảo sức khỏe đi làm việc tại nước ngoài, đồng thời công ty sẽ trao đổi với công ty tuyển dụng và được chấp thuận thì sẽ được tham gia chương trình."
                        },
                        new MessageReponse
                        {
                            Key ="Bị mù mầu có đi XKLĐ Nhật Bản được không? Kiểm tra mù mầu như nào?  ",
                            Message = "<p>M&ugrave; m&#7847;u &#7843;nh h&#432;&#7903;ng r&#7845;t nhi&#7873;u &#273;&#7871;n c&#417; h&#7897;i &#273;i XKL&#272; t&#7841;i Nh&#7853;t B&#7843;n, &#7903; m&#7897;t s&#7889; c&ocirc;ng vi&#7879;c ng&#432;&#7901;i m&ugrave; m&#7847;u b&#7883; h&#7841;n ch&#7871; nhi&#7873;u khi l&agrave;m vi&#7879;c, n&#259;ng xu&#7845;t v&agrave; ch&#7845;t l&#432;&#7907;ng c&ocirc;ng vi&#7879;c c&#361;ng s&#7869; b&#7883; th&#7845;p h&#417;n so v&#7899;i ng&#432;&#7901;i b&igrave;nh th&#432;&#7901;ng.  B&#7883; m&ugrave; m&agrave;u c&oacute; &#273;i &#273;&#432;&#7907;c XKL&#272; Nh&#7853;t B&#7843;n hay kh&ocirc;ng? C&acirc;u tr&#7843; l&#7901;i l&agrave;: Kh&ocirc;ng  Vi&#7879;c ki&#7875;m tra m&ugrave; m&#7847;u &#273;&#432;&#7907;c ti&#7871;n h&agrave;nh theo b&agrave;i test ki&#7875;m tra m&ugrave; m&agrave;u &#273;&#432;&#7907;c c&ocirc;ng ty tuy&#7875;n d&#7909;ng ch&#7845;p thu&#7853;n.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Khi phỏng vấn với chủ tuyển dụng có nên khai có người thân đang làm việc tại Nhật Bản hay không?",
                            Message = "<p>Theo quy &#273;&#7883;nh th&igrave; b&#7855;t bu&#7897;c ph&#7843;i khai &#273;&#7875; trong khi l&agrave;m vi&#7879;c c&oacute; v&#7845;n &#273;&#7873; g&igrave; b&#7845;t tr&#7855;c th&igrave; s&#7869; li&ecirc;n h&#7879; v&#7899;i h&#7885; &#273;&#7875; ph&#7889;i h&#7907;p gi&#7843;i quy&#7871;t.  Tuy&#7879;t &#273;&#7889;i kh&ocirc;ng &#273;&#432;&#7907;c khai gian d&#7889;i. N&#7871;u b&#7883; ph&aacute;t hi&#7879;n s&#7869; t&#7921; ch&#7883;u tr&aacute;ch nhi&#7879;m.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Khi đi XKLĐ Nhật Bản làm thế nào để được tăng lương?",
                            Message = "<p>Th&#7913; nh&#7845;t: Vi&#7879;c n&agrave;y ho&agrave;n to&agrave;n ph&#7909; thu&#7897;c v&agrave;o n&#259;ng l&#7921;c, th&aacute;i &#273;&#7897; l&agrave;m vi&#7879;c c&#7911;a b&#7843;n th&acirc;n ng&#432;&#7901;i lao &#273;&#7897;ng.  Th&#7913; hai. C&ocirc;ng ty x&eacute;t th&#7845;y hi&#7879;u qu&#7843; s&#7843;n xu&#7845;t kinh doanh ph&aacute;t tri&#7875;n th&igrave; s&#7869; t&#7921; &#273;&#7897;ng t&#259;ng l&#432;&#417;ng m&agrave; kh&ocirc;ng c&#7847;n ph&#7843;i &#273;&#7873; ngh&#7883;.  Th&#7913; ba. Th&#432;&#7901;ng th&igrave; &#273;i lao &#273;&#7897;ng t&#7841;i Nh&#7853;t B&#7843;n s&#7869; &#273;&#432;&#7907;c h&#432;&#7903;ng m&#7913;c l&#432;&#417;ng c&#417; b&#7843;n, ti&#7873;n l&agrave;m th&ecirc;m, ti&#7873;n th&#432;&#7903;ng v&agrave; m&#7897;t s&#7889; ph&#7909; c&#7845;p kh&aacute;c ch&#7913; kh&ocirc;ng th&#7875; t&#7921; d&ograve;i t&#259;ng l&#432;&#417;ng.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Đi XKLĐ Nhật Bản ngành cơ khí có những công việc gì?",
                            Message = "<p>C&#417; kh&iacute; c&oacute; r&#7845;t nhi&#7873;u chuy&ecirc;n ngh&agrave;nh nh&#7887; m&agrave; c&aacute;c c&ocirc;ng ty Nh&#7853;t B&#7843;n hay tuy&#7875;n d&#7909;ng bao g&#7891;m nh&#432;:  &#8730; Ngh&#7873; ti&#7879;n  &#8730; Phay, b&agrave;o  &#8730; H&agrave;n b&aacute;n t&#7921; &#273;&#7897;ng  &#8730; &#272;&uacute;c nh&#7921;a  &#8730; D&#7853;p khu&ocirc;n, &eacute;p kim lo&#7841;i  &#8730; &Eacute;p kim lo&#7841;i  &#8730;V&#7853;n h&agrave;nh m&aacute;y gia c&ocirc;ng  &#8730; L&#7855;p r&aacute;p, b&#7843;o d&#432;&#7905;ng, s&#7917;a ch&#7919;a &ocirc; t&ocirc;&#8230;  Trong nh&#7919;ng ph&acirc;n ngh&agrave;nh n&agrave;y th&igrave; y&ecirc;u c&#7847;u cao nh&#7845;t v&#7873; tay ngh&#7873; g&#7891;m ti&#7879;n, phay, b&agrave;o v&agrave; h&agrave;n. &#272;&#7889;i v&#7899;i c&aacute;c ph&acirc;n ngh&agrave;nh n&agrave;y th&igrave; y&ecirc;u c&#7847;u tay ngh&#7873; nhi&#7873;u h&#417;n l&agrave; ngo&#7841;i h&igrave;nh hay &#273;&#7897; tu&#7893;i&#8230;</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Nếu như mất một đót ngón tay có đi được Nhật Bản không?",
                            Message = "<p>&#272;&#7889;i v&#7899;i c&aacute;c &#273;&#417;n h&agrave;ng nh&#432; trong c&ocirc;ng x&#432;&#7903;ng th&igrave; vi&#7879;c m&#7845;t m&#7897;t &#273;&#7889;t s&#7869; l&agrave; m&#7897;t b&#7845;t l&#7907;i khi tham gia ph&#7887;ng v&#7845;n.  &#272;&#7889;i v&#7899;i c&aacute;c &#273;&#417;n h&agrave;ng l&agrave;m vi&#7879;c ngo&agrave;i tr&#7901;i nh&#432; x&acirc;y d&#7921;ng, d&agrave;n gi&aacute;o&#8230; th&igrave; h&#7885; kh&ocirc;ng qu&aacute; quan tr&#7885;ng vi&#7879;c m&#7845;t m&#7897;t &#273;&#7889;t. V&igrave; v&#7853;y b&#7841;n ho&agrave;n to&agrave;n c&oacute; th&#7875; tham gia theo nhu c&#7847;u tuy&#7875;n d&#7909;ng c&#7911;a c&aacute;c &#273;&#417;n h&agrave;ng &#273;&oacute;.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Có hình xăm ở vị trí kín có đi được XKLĐ Nhật Bản không?",
                            Message = "<p>Khi tham gia ch&#432;&#417;ng tr&igrave;nh XKL&#272; Nh&#7853;t t&#7841;i C&ocirc;ng ty th&igrave; b&#7841;n c&#7847;n ph&#7843;i &#273;i ki&#7875;m tra s&#7913;c kh&#7887;e t&#7841;i b&#7879;nh vi&#7879;n ch&#7881; &#273;&#7883;nh Tr&agrave;ng An. Khi &#273;&oacute;, n&#7871;u ng&#432;&#7901;i lao &#273;&#7897;ng c&oacute; h&igrave;nh x&#259;m s&#7869; &#273;&#432;&#7907;c b&#7879;nh vi&#7879;n ghi trong form th&ocirc;ng tin k&#7871;t qu&#7843; s&#7913;c kh&#7887;e t&ugrave;y v&agrave;o &#273;&#417;n h&agrave;ng cho ph&eacute;p h&igrave;nh s&#259;m hay kh&ocirc;ng, nh&#432;ng h&#7847;u h&#7871;t ng&#432;&#7901;i lao &#273;&#7897;ng ph&#7843;i cam k&#7871;t x&oacute;a h&igrave;nh s&#259;m th&igrave; m&#7899;i &#273;&#432;&#7907;c &#273;i XKL&#272;  Ng&#432;&#7901;i Nh&#7853;t kh&ocirc;ng th&iacute;ch nh&igrave;n th&#7845;y ai &#273;&oacute; c&oacute; h&igrave;nh x&#259;m, b&#7903;i theo quan ni&#7879;m c&#7911;a h&#7885;, nh&#7919;ng ng&#432;&#7901;i c&oacute; h&igrave;nh x&#259;m th&#432;&#7901;ng l&agrave; nh&#7919;ng ng&#432;&#7901;i thu&#7897;c ki&#7875;u c&ocirc;n &#273;&#7891;, ph&#7841;m t&#7897;i. V&igrave; v&#7853;y, n&#7871;u mu&#7889;n &#273;i XKL&#272; Nh&#7853;t B&#7843;n, ng&#432;&#7901;i lao &#273;&#7897;ng s&#7869; ph&#7843;i cam k&#7871;t &#273;i x&oacute;a h&igrave;nh x&#259;m th&igrave; m&#7899;i c&oacute; c&#417; h&#7897;i &#273;i XKL&#272;.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Thời gian ngắn nhất có thể nhập cảnh làm việc tại Nhật Bản là bao lâu?",
                            Message = "<p>Th&ocirc;ng th&#432;&#7901;ng theo quy &#273;&#7883;nh c&#7911;a ch&iacute;nh ph&#7911; c&#7911;a Nh&#7853;t b&#7843;n. Ng&#432;&#7901;i lao &#273;&#7897;ng khi tham gia ch&#432;&#417;ng tr&igrave;nh s&#7869; ph&#7843;i tham gia kh&oacute;a &#273;&agrave;o t&#7841;o tr&#432;&#7899;c xu&#7845;t c&#7843;nh l&agrave; t&#7915; 4 &#273;&#7871;n 6 th&aacute;ng t&#7841;i Vi&#7879;t Nam.  V&igrave; v&#7853;y th&#7901;i gian ng&#7855;n nh&#7845;t v&agrave; b&#7841;n c&oacute; th&#7875; nh&#7853;p c&#7843;nh v&agrave;o Nh&#7853;t B&#7843;n l&agrave; kho&#7843;ng 4 th&aacute;ng k&#7875; t&#7915; sau khi b&#7841;n tr&uacute;ng tuy&#7875;n ch&iacute;nh th&#7913;c &#273;&#417;n h&agrave;ng v&agrave; ph&#7909; thu&#7897;c v&agrave;o th&#7901;i gian xem x&eacute;t h&#7891; s&#417; c&#7911;a &#272;&#7841;i s&#7913; qu&aacute;n v&agrave; s&#7921; ch&iacute;nh x&aacute;c trong vi&#7879;c khai b&aacute;o th&ocirc;ng tin c&#7911;a b&#7841;n.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Lao động Nghệ An, Thanh Hóa, Hà Tĩnh có gặp khó khăn gì đi XKLĐ Nhật Bản Không?  ",
                            Message = "<p>Theo quy &#273;&#7883;nh c&#7911;a nh&agrave; n&#432;&#7899;c Vi&#7879;t Nam nghi&ecirc;m c&#7845;m vi&#7879;c tuy&#7875;n d&#7909;ng m&agrave; ph&acirc;n bi&#7879;t v&ugrave;ng mi&#7873;n hay ph&acirc;n bi&#7879;t &#273;&#7883;a ph&#432;&#417;ng do &#273;&oacute; v&#7899;i c&aacute;c lao &#273;&#7897;ng m&agrave; b&#7841;n v&#7915;a h&#7887;i th&igrave; c&ocirc;ng ty ch&uacute;ng t&ocirc;i xin tr&#7843; l&#7901;i l&agrave;: &ldquo;Kh&ocirc;ng c&oacute; kh&oacute; kh&#259;n g&igrave;&rdquo;.  Tuy nhi&ecirc;n, hi&#7879;n t&#7841;i &#7903; m&#7897;t s&#7889; c&ocirc;ng ty c&#7911;a Nh&#7853;t B&#7843;n c&oacute; ng&#432;&#7901;i lao &#273;&#7897;ng Vi&#7879;t Nam l&agrave; ng&#432;&#7901;i Ngh&#7879; An, Thanh H&oacute;a, H&agrave; T&#297;nh c&oacute; nh&#7919;ng bi&#7875;u hi&#7879;n kh&ocirc;ng t&#7889;t th&igrave; c&#361;ng c&oacute; m&#7897;t s&#7889; c&ocirc;ng ty tuy&#7875;n d&#7909;ng c&#7911;a Nh&#7853;t B&#7843;n h&#7885; kh&ocirc;ng &#273;&#7891;ng &yacute; tuy&#7875;n nh&#7919;ng ng&#432;&#7901;i &#7903; &#273;&#7883;a ph&#432;&#417;ng n&agrave;y. Do v&#7853;y &#273;&oacute; c&#361;ng l&agrave; b&#7845;t l&#7907;i v&agrave; kh&oacute; kh&#259;n cho c&aacute;c b&#7841;n c&oacute; nguy&#7879;n v&#7885;ng.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Nếu tự ý phá bỏ hợp đồng với Công ty Nhật Bản thì bị phạt như nào?",
                            Message = "<p>S&#7869; b&#7883; tr&#7909;c xu&#7845;t v&#7873; n&#432;&#7899;c &#273;&#7891;ng th&#7901;i ph&#7843;i b&#7891;i th&#432;&#7901;ng h&#7907;p &#273;&#7891;ng cho c&ocirc;ng ty ti&#7871;p nh&#7853;n theo quy &#273;&#7883;nh.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Thi chuyển giai đoạn ở Nhật Bản như nào?",
                            Message = "<p>&#272;&#7889;i v&#7899;i ch&#432;&#417;ng tr&igrave;nh &#273;i TTSKN Nh&#7853;t B&#7843;n th&igrave; sau khi nh&#7853;p c&#7843;nh v&agrave;o Nh&#7853;t B&#7843;n s&#7869; c&oacute; 2 k&#7923; thi l&agrave;:  + Sau 1 n&#259;m nh&#7853;p c&#7843;nh v&agrave;o Nh&#7853;t B&#7843;n.  + Sau khi ho&agrave;n th&agrave;nh h&#7871;t h&#7907;p &#273;&#7891;ng 3 n&#259;m.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Hủy đơn hàng đi Nhật Bản có lấy lại được tiền không?",
                            Message = "<p>M&#7897;t l&agrave; n&#7871;u do c&ocirc;ng ty b&ecirc;n Nh&#7853;t B&#7843;n b&aacute;o h&#7911;y v&#7899;i 1 l&yacute; do n&agrave;o &#273;&oacute; th&igrave; b&#7841;n s&#7869; l&#7845;y l&#7841;i &#273;&#432;&#7907;c c&aacute;c kho&#7843;n ti&#7873;n &#273;&atilde; &#273;&oacute;ng (n&#7871;u c&oacute;) tr&#7915; ti&#7873;n h&#7885;c th&igrave; kh&ocirc;ng &#273;&#432;&#7907;c l&#7845;y l&#7841;i.  Hai l&agrave; n&#7871;u b&#7841;n l&agrave; ng&#432;&#7901;i &#273;&#417;n ph&#432;&#417;ng ph&aacute; b&#7887;, h&#7911;y hay khai man h&#7891; s&#417; m&agrave; kh&ocirc;ng &#273;&#432;&#7907;c c&#7845;p t&#432; c&aacute;ch l&#432;u tr&uacute; v&agrave; b&#7883; ph&aacute;t hi&#7879;n th&igrave; s&#7869; kh&ocirc;ng l&#7845;y l&#7841;i &#273;&#432;&#7907;c b&#7845;t k&#7875; m&#7897;t kho&#7843;n ph&iacute; n&agrave;o &#273;&atilde; &#273;&oacute;ng.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Nếu quay lại Nhật Bản lần 2 thì như nào?",
                            Message = "<p>Theo quy &#273;&#7883;nh c&#7911;a Ch&iacute;nh ph&#7911; Nh&#7853;t B&#7843;n. N&#7871;u b&#7841;n &#273;&atilde; k&#7871;t th&uacute;c ch&#432;&#417;ng tr&igrave;nh TTSKN Nh&#7853;t B&#7843;n l&#7847;n 1 m&agrave; kh&ocirc;ng vi ph&#7841;m c&aacute;c quy &#273;&#7883;nh c&#7911;a nh&agrave; m&aacute;y hay vi ph&#7841;m ph&aacute;p lu&#7853;t c&#7911;a Nh&#7853;t B&#7843;n th&igrave; ho&agrave;n to&agrave;n c&oacute; th&#7875; quay l&#7841;i l&#7847;n 2 theo th&#7887;a thu&#7853;n c&#7911;a nh&agrave; m&aacute;y v&agrave; ng&#432;&#7901;i lao &#273;&#7897;ng.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Làm thế nào để đi được chương trình kỹ sư hay Đặc định",
                            Message = "<p>&#272;&#7889;i v&#7899;i ch&#432;&#417;ng tr&igrave;nh K&#7929; s&#432;: Y&ecirc;u c&#7847;u t&#7889;i thi&#7875;u t&#7889;t nghi&#7879;p Cao &#273;&#7859;ng ho&#7863;c &#272;&#7841;i h&#7885;c c&aacute;c chuy&ecirc;n ng&agrave;nh k&#7929; thu&#7853;t t&#7841;i Vi&#7879;t Nam.  &#272;&#7889;i v&#7899;i ch&#432;&#417;ng tr&igrave;nh &#272;&#7863;c &#273;&#7883;nh: Sau khi k&#7871;t th&uacute;c ch&#432;&#417;ng tr&igrave;nh TTSKN s&#7889; 2 m&agrave; c&oacute; ch&#7913;ng ch&#7881; v&agrave; kh&ocirc;ng vi ph&#7841;m b&#7845;t c&#7913; m&#7897;t quy &#273;&#7883;nh n&agrave;o c&#7911;a ph&aacute;p lu&#7853;t Nh&#7853;t B&#7843;n th&igrave; ho&agrave;n to&agrave;n c&oacute; th&#7875; n&#7897;p h&#7891; s&#417; &#273;&#7875; tham gia thi tuy&#7875;n chuy&#7875;n giai &#273;o&#7841;n.</p>"
                        },
                        new MessageReponse
                        {
                            Key ="Đã tường phẫu thuật có đi XKLĐ Nhật Bản không?    ",
                            Message = "<p>V&#7873; c&#417; b&#7843;n n&#7871;u b&#7841;n &#273;&#7843;m b&#7843;o &#273;&#432;&#7907;c s&#7913;c kh&#7887;e theo quy &#273;&#7883;nh c&#7911;a B&#7879;nh vi&#7879;n hay B&#7897; Y t&#7871; c&oacute; th&#7849;m quy&#7873;n th&igrave; b&#7841;n ho&agrave;n to&agrave;n c&oacute; th&#7875; tham gia ch&#432;&#417;ng tr&igrave;nh TTSKN Nh&#7853;t B&#7843;n b&igrave;nh th&#432;&#7901;ng</p>"
                        },
                        new MessageReponse
                        {
                            Key ="",
                            Message = ""
                        },
                        new MessageReponse
                        {
                            Key ="",
                            Message = ""
                        },
                        new MessageReponse
                        {
                            Key ="",
                            Message = ""
                        },
                        new MessageReponse
                        {
                            Key ="",
                            Message = ""
                        },
                        new MessageReponse
                        {
                            Key ="",
                            Message = ""
                        },
                        new MessageReponse
                        {
                            Key ="",
                            Message = ""
                        },
                        new MessageReponse
                        {
                            Key ="",
                            Message = ""
                        },
                        new MessageReponse
                        {
                            Key ="",
                            Message = ""
                        },
                        new MessageReponse
                        {
                            Key ="",
                            Message = ""
                        },
                        new MessageReponse
                        {
                            Key ="",
                            Message = ""
                        },
                        new MessageReponse
                        {
                            Key ="",
                            Message = ""
                        }
                    };

                    responseText = lstQuestionAnswer.FirstOrDefault(x => x.Key.Contains(msg.Text))?.Message.ToString();
                    if (!string.IsNullOrEmpty(responseText))
                    {
                        Console.WriteLine(msg.Text);
                    }
                    else
                    {
                        responseText = "Hello";
                    }
                    MsgBuilder builder = new MsgBuilder();
                    builder.AppendText(responseText);
                    //responseMsg = MsgBuilder.BuildTextMessage(responseText);
                    responseMsg = builder.Message;
                }
                else
                {
                    responseMsg = msg;
                    //Extract more information
                    var mentions = msg.GetMentions();
                    foreach (var m in mentions)
                    {
                        Console.WriteLine($"Mentions:{m.Val}");
                    }

                    var images = msg.GetImages();
                    foreach (var image in images)
                    {
                        Console.WriteLine($"Image:Name={image.Name} Mime={image.Mime}");
                    }

                    var hashTags = msg.GetHashTags();
                    foreach (var hash in hashTags)
                    {
                        Console.WriteLine($"HashTags:{hash.Val}");
                    }

                    var links = msg.GetLinks();
                    foreach (var link in links)
                    {
                        Console.WriteLine($"Links:{link.Url}");
                    }

                    var files = msg.GetGenericAttachment();
                    foreach (var f in files)
                    {
                        Console.WriteLine($"Image:Name={f.Name} Mime={f.Mime}");
                    }
                }
                return responseMsg;
            }
        }

        private static ChatBot bot;

        private static void Main(string[] args)
        {
            Console.CancelKeyPress += Console_CancelKeyPress;
            string schemaArg = string.Empty;
            string secretArg = string.Empty;
            string cookieFile = string.Empty;
            string host = string.Empty;
            string listen = string.Empty;
            Parser.Default.ParseArguments<CmdOptions>(args)
                   .WithParsed<CmdOptions>(o =>
                   {
                       if (!string.IsNullOrEmpty(o.Host))
                       {
                           host = o.Host;
                           Console.WriteLine($"gRPC server:{host}");
                       }
                       if (!string.IsNullOrEmpty(o.Listen))
                       {
                           listen = o.Listen;
                           Console.WriteLine($"Plugin API calls Listen server:{listen}");
                       }
                       if (!string.IsNullOrEmpty(o.Token))
                       {
                           schemaArg = "token";
                           secretArg = Encoding.ASCII.GetString(Encoding.Default.GetBytes(o.Token));
                           Console.WriteLine($"Login in with token {o.Token}");
                           bot = new ChatBot(serverHost: host, listen: listen, schema: schemaArg, secret: secretArg);
                       }
                       //else if (!string.IsNullOrEmpty(o.Basic))
                       //{
                       schemaArg = "basic";
                       secretArg = Encoding.UTF8.GetString(Encoding.Default.GetBytes("chatbot:123456"));
                       var secret2 = System.Text.Encoding.UTF8.GetBytes("datlt3:123456");
                       Console.WriteLine($"Login in with login:password {o.Basic}");
                       bot = new ChatBot(serverHost: host, listen: listen, schema: schemaArg, secret: secretArg);
                       //}
                       //else
                       //{
                       //    cookieFile = o.CookieFile;
                       //    Console.WriteLine($"Login in with cookie file {o.CookieFile}");
                       //    bot = new ChatBot(serverHost: host, listen: listen, cookie: cookieFile, schema: string.Empty, secret: string.Empty);
                       //    if (bot.ReadAuthCookie(out var schem, out var secret))
                       //    {
                       //        bot.Schema = schem;
                       //        bot.Secret = secret;
                       //    }
                       //    else
                       //    {
                       //        Console.WriteLine("Login in with cookie file failed, please check your credentials and try again... Press any key to exit.");
                       //        Console.ReadKey();
                       //        return;
                       //    }
                       //}
                       bot.ServerDataEvent += Bot_ServerDataEvent;
                       bot.ServerMetaEvent += Bot_ServerMetaEvent;
                       bot.ServerPresEvent += Bot_ServerPresEvent;
                       bot.CtrlMessageEvent += Bot_CtrlMessageEvent;
                       bot.LoginSuccessEvent += Bot_LoginSuccessEvent;
                       bot.LoginFailedEvent += Bot_LoginFailedEvent;
                       bot.DisconnectedEvent += Bot_DisconnectedEvent;
                       //your should set your chatserver's http base url and api access key to handle larget file upload
                       bot.SetHttpApi("http://localhost:6660", "AQAAAAABAABtfBKva9nJN3ykjBi0feyL");
                       bot.BotResponse = new BotReponse(bot);
                       bot.Start().Wait();

                       Console.WriteLine("[Bye Bye] ChatBot Stopped");
                   });
        }

        private static void Bot_DisconnectedEvent(object sender, EventArgs e)
        {
            Console.WriteLine("[!!!Disconnected!!!]");
        }

        private static void Bot_LoginFailedEvent(object sender, EventArgs e)
        {
            Console.WriteLine("[!!!Login Failed!!!]");
        }

        private static void Bot_LoginSuccessEvent(object sender, EventArgs e)
        {
            Console.WriteLine("[!!!Login Success!!!]");
        }

        private static void Bot_CtrlMessageEvent(object sender, ChatBot.CtrlMessageEventArgs e)
        {
            //Console.WriteLine($"[Ctrl Message] {e.Code} {e.Id}  {e.Topic}  {e.Text}  {e.Params}  {e.Type}  {e.HasError}");
        }

        private static void Bot_ServerPresEvent(object sender, ChatBot.ServerPresEventArgs e)
        {
            //Console.WriteLine($"[Pres Message] {e.Pres.ToString()}");
        }

        private static void Bot_ServerMetaEvent(object sender, ChatBot.ServerMetaEventArgs e)
        {
            //Console.WriteLine($"[Meta Message] {e.Meta.ToString()}");
        }

        private static void Bot_ServerDataEvent(object sender, ChatBot.ServerDataEventArgs e)
        {
            //Console.WriteLine($"[Data Message] {e.Data.ToString()}");
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            bot.Stop();
        }
    }
}