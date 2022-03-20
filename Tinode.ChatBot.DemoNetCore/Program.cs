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
                        },
                        new MessageReponse
                        {
                            Key ="",
                            Message = ""
                        }
                    };

                    responseText = lstQuestionAnswer.FirstOrDefault(x => x.Key.Contains(msg.Text)).Message.ToString();
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
                       secretArg = Encoding.UTF8.GetString(Encoding.Default.GetBytes("alice:alice123"));
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