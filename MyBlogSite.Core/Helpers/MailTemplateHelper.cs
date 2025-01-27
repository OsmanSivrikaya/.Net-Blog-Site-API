namespace MyBlogSite.Core.Helpers;

public static class MailTemplateHelper
{
    private const string style = @"<style>
                        body {
                            font-family: Arial, sans-serif;
                            background-color: #f4f7fc;
                            color: #333;
                            margin: 0;
                            padding: 0;
                        }
                        .container {
                            width: 100%;
                            max-width: 600px;
                            margin: 0 auto;
                            background-color: #ffffff;
                            border-radius: 8px;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                            overflow: hidden;
                        }
                        .header {
                            background-color: #4CAF50;
                            color: white;
                            padding: 20px;
                            text-align: center;
                        }
                        .content {
                            padding: 20px;
                        }
                        .content h2 {
                            color: #4CAF50;
                        }
                        .content p {
                            line-height: 1.6;
                        }
                        .footer {
                            background-color: #f4f7fc;
                            padding: 20px;
                            text-align: center;
                            font-size: 14px;
                            color: #777;
                        }
                        .btn {
                            display: inline-block;
                            background-color: #4CAF50;
                            color: white;
                            padding: 10px 20px;
                            text-decoration: none;
                            border-radius: 5px;
                            margin-top: 15px;
                        }
                        .btn:hover {
                            background-color: #45a049;
                        }
                    </style>";

    public static string WelcomeMessage(string fullName)
    {
        var message = $@"
                <!DOCTYPE html>
                <html lang=""tr"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Hoş Geldiniz!</title>
                    {style}
                </head>
                <body>
                
                    <div class=""container"">
                        <div class=""header"">
                            <h1>Blogumuza Hoş Geldiniz!</h1>
                        </div>
                        <div class=""content"">
                            <h2>Merhaba {fullName},</h2>
                            <p>Blogumuza üye olduğunuz için teşekkür ederiz! Sizi aramızda görmekten büyük mutluluk duyuyoruz. Artık blog yazılarını keşfedebilir ve paylaşabilirsiniz.</p>
                            <p>Eğer herhangi bir sorunuz ya da yardıma ihtiyacınız olursa, bizimle her zaman iletişime geçebilirsiniz.</p>
                            <p>Başlamak için kişisel kontrol panelinizi ziyaret edebilirsiniz:</p>
                        </div>
                        <div class=""footer"">
                            <p>&copy; 2025 Blogumuz. Tüm hakları saklıdır.</p>
                            <p>Bu e-postayı siz kaydolmadıysanız dikkate almayabilirsiniz.</p>
                        </div>
                    </div>
                
                </body>
                </html>";

        return message;
    }
    public static string PasswordResetMessage(string fullName, string resetUrl)
    {
        var message = $@"
                <!DOCTYPE html>
                <html lang=""tr"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Şifre Sıfırlama Talebi</title>
                    {style}
                </head>
                <body>
                
                    <div class=""container"">
                        <div class=""header"">
                            <h1>Şifre Sıfırlama Talebi</h1>
                        </div>
                        <div class=""content"">
                            <h2>Merhaba {fullName},</h2>
                            <p>Hesabınız için şifre sıfırlama talebi aldık. Şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayın:</p>
                            <a href=""{resetUrl}"" class=""btn"">Şifremi Sıfırla</a>
                            <p>Bağlantıya tıkladığınızda, şifrenizi güvenli bir şekilde değiştirebileceksiniz.</p>
                            <p>Bu işlemi yapmadıysanız, e-postayı göz ardı edebilirsiniz.</p>
                        </div>
                        <div class=""footer"">
                            <p>&copy; 2025 Blogumuz. Tüm hakları saklıdır.</p>
                        </div>
                    </div>
                
                </body>
                </html>";

        return message;
    }
}