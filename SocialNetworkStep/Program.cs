using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialNetworkStep
{
    class Program
    {
        List<Notification> notifications = new List<Notification>();

        bool[] isViewed = new bool[] { false, false, false };
        bool[] isLiked = new bool[] { false, false, false };
        public void ShowPostById(int id, Post[] posts = default)
        {
            ++posts[id - 1].ViewCount;
            isViewed[id - 1] = true;
            Console.WriteLine(posts[id - 1].Content);
            notifications.Add(new ViewNotf
            {
                Text = $"User view post id:{id}",
                CreatTime = DateTime.Now
            });
        }

        public void LikePostById(int id, Post[] posts = default)
        {
            if (isViewed[id - 1] == false)
            {
                Console.WriteLine("You should look at post firstly");
                notifications.Add(new LikeNotf
                {
                    Text = $"User cant like post id:{id},because he/she dont look post yet",
                    CreatTime = DateTime.Now
                });
                return;
            }
            if (isLiked[id - 1] == true)
            {
                Console.WriteLine("You have already liked this post");
                notifications.Add(new LikeNotf
                {
                    Text = $"User cant like post id:{id},because he/she have already like it",
                    CreatTime = DateTime.Now
                });
                return;
            }
            ++posts[id - 1].LikeCount;
            Console.WriteLine("You like this post");
            isLiked[id - 1] = true;
            notifications.Add(new LikeNotf
            {

                Text = $"User like post id:{id}",
                CreatTime = DateTime.Now
            });
        }

        public static bool Login(string username, int password,
            string sys_username, int sys_password)
        {
            if (username == sys_username && password == sys_password)
            {
                Console.WriteLine("::Log in::");
                Thread.Sleep(800);
                return true;
            }
            else if (username == sys_username && password != sys_password)
            {
                Console.WriteLine("Password is incorrect:");
                Thread.Sleep(800);
                return false;
            }
            else if (username != sys_username && password == sys_password)
            {
                Console.WriteLine("Username is incorrect:");
                Thread.Sleep(800);
                return false;
            }
            else
            {
                Console.WriteLine("Username and password are incorrect:");
                Thread.Sleep(800);
                return false;
            }
        }

        public static void SignIn(string sys_username, int sys_password)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Password:");
                string password = Console.ReadLine();

                int hp = DisplayPasswordHashCode(password);

                if (Login(username, hp, sys_username, sys_password))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Again pls");
                }
            }
        }

        public static int DisplayPasswordHashCode(string s)
        {
            int hash = s.GetHashCode();
            return hash;
        }

        enum Type
        {
            Admin = 1, User, Exit
        };

        enum UserProcess
        {
            ViewPost = 1, LikePost, Exit
        };

        enum AdminProcess
        {
            ShowPost = 1, ShowPostLike, ShowNotification, Exit
        };


        static void Main(string[] args)
        {
            Program p = new Program();

            User user = new User
            {
                Name = "ELi",
                Surname = "ELiev",
                Age = 5
            };
            Admin admin = new Admin
            {
                Name = "Ali"
            };
            Post post = new Post
            {
                Content = "New Zealand tells tourists to stop copying other people's travel photos"
            };
            Post post1 = new Post
            {
                Content = "Biden declares 'America is back' as he announces major foreign policy shifts"
            };
            Post post2 = new Post
            {
                Content = "How Trans Europe Express trains could be making a comeback"
            };

            Post[] posts = new Post[3] { post, post1, post2 };


            //List<Notification> notifications = new List<Notification>();


            while (true)
            {
                Console.WriteLine("1)Admin\n2)User\n3)Exit");
                char selectt = Convert.ToChar(Console.ReadLine());

                while (selectt !='1' && selectt !='2' && selectt !='3')
                {
                    Console.WriteLine("Input again");
                    selectt = Convert.ToChar(Console.ReadLine());
                }

                int select = (int)selectt-'0';
                if ((Type)select == Type.Admin)
                {
                    SignIn(admin.Username, admin.PasswordHash);
                    while (true)
                    {
                        Console.WriteLine("1)Show post view\n2)Show Post like count\n" +
                            "3)Notifications\n4)Exit");
                        char nn = Convert.ToChar(Console.ReadLine());
                        while (nn != '1' && nn != '2' && nn != '3' && nn != '4')
                        {
                            Console.WriteLine("Input again");
                            nn = Convert.ToChar(Console.ReadLine());
                        }
                        int id;
                        int n = (int)nn - '0';
                        if ((AdminProcess)n == AdminProcess.ShowPost)
                        {
                            Console.WriteLine("Id:");
                            id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(posts[id - 1].Content);
                            Console.WriteLine("View Count:" + posts[id - 1].ViewCount);

                        }
                        else if ((AdminProcess)n == AdminProcess.ShowPostLike)
                        {
                            Console.WriteLine("Id:");
                            id = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                Console.WriteLine(posts[id - 1].Content);
                                Console.WriteLine(posts[id - 1].LikeCount);
                            }
                            catch (IndexOutOfRangeException ex) when (id > 0)
                            {
                                try
                                {
                                    throw new NullException("Index is greater than array size", DateTime.Now, 161, "Program.cs");
                                }
                                catch (NullException ek)
                                {
                                    ek.Show();
                                }
                            }
                            catch (IndexOutOfRangeException ex) when (id <= 0)
                            {
                                try
                                {
                                    throw new NullException("Index is negative or zero", DateTime.Now, 174, "Program.cs");
                                }
                                catch (NullException ek)
                                {
                                    ek.Show();
                                }
                            }
                        }
                        else if ((AdminProcess)n == AdminProcess.ShowNotification)
                        {
                            foreach (var item in p.notifications)
                            {
                                item.PrintMessage();
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                else if ((Type)select == Type.User)
                {
                    SignIn(user.Username, user.PasswordHash);
                    while (true)
                    {
                        Console.WriteLine("1)Show post\n2)Like Post\n3)Exit");
                        char nn = Convert.ToChar(Console.ReadLine());
                        while (nn != '1' && nn != '2' && nn != '3')
                        {
                            Console.WriteLine("Input again");
                            nn = Convert.ToChar(Console.ReadLine());
                        }
                        int id;
                        int n = (char)nn - '0';
                        if ((UserProcess)n == UserProcess.ViewPost)
                        {
                            Console.WriteLine("Id:");
                            id = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                p.ShowPostById(id, posts);

                            }
                            catch (IndexOutOfRangeException ex) when (id >= 0)
                            {
                                try
                                {
                                    throw new NullException("Index is greater than array size", DateTime.Now, 161, "Program.cs");
                                }
                                catch (NullException ek)
                                {
                                    ek.Show();
                                }
                            }
                            catch (IndexOutOfRangeException ex) when (id < 0)
                            {
                                try
                                {
                                    throw new NullException("Index is negative", DateTime.Now, 174, "Program.cs");
                                }
                                catch (NullException ek)
                                {
                                    ek.Show();
                                }
                            }
                        }
                        else if ((UserProcess)n == UserProcess.LikePost)
                        {
                            Console.WriteLine("Id:");
                            id = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                p.LikePostById(id, posts);

                            }
                            catch (IndexOutOfRangeException ex) when (id >= 0)
                            {
                                try
                                {
                                    throw new NullException("Index is greater than array size", DateTime.Now, 161, "Program.cs");
                                }
                                catch (NullException ek)
                                {
                                    ek.Show();
                                }
                            }
                            catch (IndexOutOfRangeException ex) when (id < 0)
                            {
                                try
                                {
                                    throw new NullException("Index is negative", DateTime.Now, 174, "Program.cs");
                                }
                                catch (NullException ek)
                                {
                                    ek.Show();
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                }
                else
                {
                    break;
                }

            }

        }
    }
}

