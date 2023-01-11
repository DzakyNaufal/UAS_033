using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_033
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DoublyLinkedList
    {
        class Node
        {
            public int IDbar;
            public int harbar;
            public string name;
            public string jenbar;
            public Node next;
            public Node prev;
        }

        class DoubleLinkedList
        {
            Node START;
            public DoubleLinkedList()
            {
                START = null;
            }
            public void addNode()
            {
                int IDB;
                int hb;
                string nm;
                string jb;
                Console.Write("ID Barang : ");
                IDB = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nNama Barang : ");
                nm = Console.ReadLine();
                Console.Write("\nJenis Barang : ");
                jb = Console.ReadLine();
                Console.Write("Harga Barang : ");
                hb = Convert.ToInt32(Console.ReadLine());
                Node newnode = new Node();
                newnode.IDbar = IDB;
                newnode.harbar = hb;
                newnode.name = nm;
                newnode.jenbar = jb;
                if (START == null || IDB <= START.IDbar)
                {
                    if ((START != null) && (IDB == START.IDbar))
                    {
                        Console.WriteLine("\nDuplicate roll numbers not allowed");
                        return;
                    }
                    newnode.next = START;
                    if (START != null)
                        START.prev = newnode;
                    newnode.prev = null;
                    START = newnode;
                    return;
                }
                Node previous, current;
                for (current = previous = START; current != null && IDB >= current.IDbar; previous = current, current = current.next)
                {
                    if (IDB == current.IDbar)
                    {
                        Console.WriteLine("\nDuplicate roll numbers not allowed");
                        return;
                    }
                }
                newnode.next = current;
                newnode.prev = newnode;

                if (current == null)
                {
                    newnode.next = null;
                    previous.next = newnode;
                    return;
                }
                current.prev = newnode;
                previous.next = newnode;
            }

            public bool Search(int rollNo, ref Node previous, ref Node current)
            {
                for (previous = current = START; current != null && rollNo != current.IDbar; previous = current, current = current.next)
                { }
                return (current != null);
            }
            public void traverse()
            {
                if (listEmpty())
                    Console.WriteLine("\nList is Empty");
                else
                {
                    Console.WriteLine("\nList barang anda " + "roll numbers are:\n");
                    Node currentNode;
                    for (currentNode = START; currentNode != null;
                        currentNode = currentNode.next)
                        Console.Write(currentNode.IDbar + "  " + currentNode.name + "  " + currentNode.jenbar + "  " + currentNode.harbar + "\n");
                }
            }
            public bool listEmpty()
            {
                if (START == null)
                    return true;
                else
                    return false;
            }
            static void Main(string[] args)
            {
                DoubleLinkedList obj = new DoubleLinkedList();
                while (true)
                {
                    try
                    {
                        Console.Write("\n============================");
                        Console.Write("\n Menu" +
                            "\n 1. Masukkan data barang" +                            
                            "\n 2. Lihat Data Barang" +
                            "\n 3. Cari Barang" +
                            "\n 4. Keluar \n" +
                            "\nMasukkan pilihanmu (1-4): ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.addNode();
                                }
                                break;
                            case '2':
                                {
                                    obj.traverse();
                                }
                                break;                           
                            case '3':
                                {
                                    if (obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nData Kosong");
                                        break;
                                    }
                                    Node prev, curr;
                                    prev = curr = null;
                                    Console.Write("\nMasukkan ID barang yang ingin dicari: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref prev, ref curr) == false)
                                        Console.WriteLine("\nData tidak ditemukan");
                                    else
                                    {
                                        Console.Write("\nData ditemukan");
                                        Console.WriteLine("\n============================");
                                        Console.Write("\nID Barang: " + curr.IDbar);
                                        Console.Write("\nNama Barang: " + curr.name);
                                        Console.Write("\nJenis Barang: " + curr.jenbar);
                                        Console.Write("\nHarga Barang: " + curr.harbar);
                                        Console.WriteLine("\n============================");
                                    }
                                }
                                break;
                            case '4':
                                return;
                            default:
                                {
                                    Console.WriteLine("\nInvalid option");
                                }
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Check for the values entered.");
                    }
                }
            }
        }
    }
}

/*

2. Algoritma DoublyLinkedList
karena algoritma ini bisa digunakan untuk menyimpan data

3. rear, front

4. a. ada 5
   b. Preorder
        50, 48, 30, 20, 15, 25, 32, 31, 35, 70, 65, 67, 66, 69, 90, 98, 94, 99.

*/
