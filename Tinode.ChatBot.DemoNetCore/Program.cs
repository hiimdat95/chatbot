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
                            Key ="Những quyền lợi khi đi làm việc tại Nhật Bản ?",
                            Message = "<p>Là công dân Việt Nam có nguyện vọng đi làm việc tại nước ngoài mà trong độ tuổi Công ty có nhu cầu tuyển dụng (phải đảm bảo đủ 18 tuổi trở lên, Công ty không tuyển những người dưới 18 tuổi tính đủ theo ngày sinh).  "
                            +"<br/>"
                            +"<br/>"
                            +"Không phân biệt vùng miền. giới tính … "
                            +"<br/>"
                            +"<br/>"
                            +"Không phải là các đối tượng đang chịu sự quản lý của pháp luật, không phải là những đối tượng đang thi hành án mà chưa được xóa án tích. Lý lịch phải được xác nhận là đối tượng có nhân thân tốt chấp hành tốt mọi đường lối chính sách của Đảng, Nhà nước"
                            +"</p>"
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