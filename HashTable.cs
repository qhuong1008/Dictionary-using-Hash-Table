using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    class HashTable
    {
        public LinkedList[] hashtable = new LinkedList[27];
        public HashTable()
        {
            for (int i = 0; i < 27; i++)
            {
                hashtable[i] = new LinkedList();
            }
        }
        public void initHashtable()
        {
            for (int i = 0; i < 27; i++)
            {
                hashtable[i] = new LinkedList();
            }
        }
        public void Kitu()
        {
            for (int i = 0; i < 27; i++)
            {
                hashtable[i].ChangeKitu();
            }
        }

        public int HashFunc(string s)
        {
            char c = s[0];
            
            int vitri = 0;
            if (c >= 'a' && c <= 'z')
            {
                for (char i = 'a'; i <= 'z'; i++)
                {
                    if (c == i)
                        break;
                    vitri++;
                }
            }
            else
                vitri = 26;
            return vitri;
        }
       
        public void InsertWord(string english, string type, string meaning)
        {
            int bucket = HashFunc(english);
            hashtable[bucket].AddLast(english, type, meaning);
        }
       
        public Node SearchWord(string x)
        {
            int bucket = HashFunc(x);
            Node p = hashtable[bucket].SearchNode(x);
            return p;
        }
        public bool DeleteWord(string x)
        {
            int bucket = HashFunc(x);
            Node p = hashtable[bucket].Head;
            int i = 1;
            while (p != null)
            {
                if (p.english == x)
                {
                    hashtable[bucket].RemoveNode(i); 
                    i--; 
                    return true;
                }
                p = p.Next;
                i++;
            }
            return false;
        }
        public Node UpdateWord(string eng, string type, string meaning)
        {
            Node p = searchInHash(eng);
            if(p!=null)
            {
                p.english = eng;
                p.type = type;
                p.meaning = meaning;
            }
            
            return p;
        }
        public Node searchInHash(string x)
        {
            int bucket = HashFunc(x);
            Node p = hashtable[bucket].SearchNode(x);
            return p;
        }


        public void PrintHashTable(int bucket)
        {
            Node temp = hashtable[bucket].Head;
            while (temp != null)
            {
                Console.WriteLine(temp.english);
                Console.WriteLine(temp.type);
                Console.WriteLine(temp.meaning);
                temp = temp.Next;
            }
        }
    }
}
