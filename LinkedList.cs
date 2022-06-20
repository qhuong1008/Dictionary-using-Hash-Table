using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    public class LinkedList
    {
        public Node Head;
        public Node Tail;
        public Node CreateNode(string eng, string type, string viet)
        {
            Node p = new Node();
            p.english = eng;
            p.type = type;
            p.meaning = viet;
            p.Next = null;
            p.Pre = null; 
            return p;
        }
        public int IsEmptyList()
        {
            if (this.Head == null)
                return 1;
            return 0;
        }

        public void AddFirst(string eng, string type, string viet)
        {
            Node p = this.CreateNode(eng, type, viet);
            if (IsEmptyList() == 1)
            {
                this.Head = this.Tail = p;
            }
            else
            {
                p.Next = this.Head;
                this.Head.Pre = p;
                this.Head = p;
                p.Pre = null;
            }
        }

        public void AddLast(string eng, string type, string viet)
        {
            Node p = this.CreateNode(eng, type, viet);
            if (IsEmptyList() == 1)
            {
                this.Head = this.Tail = p;
            }
            else
            {
                this.Tail.Next = p;
                p.Pre = this.Tail;
                this.Tail = p;

            }
        }

        public void AddNode(string eng, string type, string viet, int pos)
        {
            Node newNode = this.CreateNode(eng, type, viet);
            if (pos < 1)
            {
                Console.Write("\nVị trí cần thêm không hợp lệ!!!");
            }
            else if (pos == 1)
            {
                //Nếu vị trí bằng 1, đặt node thành Head
                newNode.Next = this.Head;
                this.Head.Pre = newNode;
                this.Head = newNode;
            }
            else
            {
                //Tìm vị trí cần thêm
                Node temp = this.Head;
                for (int i = 1; i < pos - 1; i++)
                {
                    if (temp != null)
                    {
                        temp = temp.Next;
                    }
                }
                if (temp != null)
                {
                    newNode.Next = temp.Next;
                    newNode.Pre = temp;
                    temp.Next = newNode;
                    if (newNode.Next != null)
                        newNode.Next.Pre = newNode;
                }
                else
                {

                    Console.Write("\nVị trí cần thêm có Node trước đó là null!!!");
                }
            }
        }

        public void AddVietMean(string vietMean)
        {
            if (IsEmptyList() == 1)
            {
                return;
            }
            this.Tail.meaning = vietMean;
        }

        public void RemoveFirst()
        {
            if (IsEmptyList() == 1)
                Console.WriteLine("\nDanh sach rong !");
            else
            {
                Node p = this.Head;
                if (this.Head == this.Tail)
                    this.Head = this.Tail = null;
                else
                {
                    this.Head = this.Head.Next;
                    this.Head.Pre = null;
                }
                p = null;
            }
        }

        public void RemoveLast()
        {
            if (IsEmptyList() == 1)
                Console.WriteLine("Danh sach rong!!!");
            else
            {
                Node p = this.Tail;
                if (this.Head == this.Tail)
                    this.Head = this.Tail = null;
                else
                {
                    this.Tail = this.Tail.Pre;
                    this.Tail.Next = null;
                }
                p = null;
            }
        }
        public Node SearchNode(String x)
        {
            Node p = this.Head;
            while (p != null)
            {
                if (p.english == x) return p;//tim thay
                p = p.Next;
            }
            return null; //ko tim thay
        }

        public void RemoveNode(int pos)
        {
            if (IsEmptyList() == 1)
                return;
            else
            {

                if (pos < 1)
                {
                    Console.Write("\nVị trí xóa không hợp lệ!");
                }
                else if (pos == 1 && this.Head != null)
                {
                    //Remove first
                    Node nodeDel = this.Head;
                    this.Head = this.Head.Next;
                    nodeDel = null;
                    if (this.Head != null)
                        this.Head.Pre = null;
                }
                else
                {
                    //Tìm vị trí cần xóa
                    Node temp = new Node();
                    temp = this.Head;
                    for (int i = 1; i < pos - 1; i++)
                    {
                        if (temp != null)
                        {
                            temp = temp.Next;
                        }
                    }

                    if (temp != null && temp.Next != null)
                    {
                        Node nodeDel = temp.Next;
                        temp.Next = temp.Next.Next;
                        if (temp.Next.Next != null)
                            temp.Next.Next.Pre = temp.Next;
                        nodeDel = null;
                    }
                    else
                    {
                        Console.Write("\nTừ cần xóa là null!!!");
                    }
                }
            }
        }


        public void PrintList()
        {
            for (Node p = this.Head; p != null; p = p.Next)
            {
                Console.Write(p.english + "\n " + p.type + "\n " + p.meaning);
            }
        }
        public void ChangeKitu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            for (Node p = this.Head; p != null; p = p.Next)
            {
                string meaning2 = p.meaning.Replace("-", "\r\n- ")
                                           .Replace("+", " - ")
                                           .Replace("*", "\r\n*Từ loại:")
                                           .Replace("=", "\r\nVD: ");
                
                                                                                  
                p.meaning = meaning2;
                             
            }
        }
    }
}
