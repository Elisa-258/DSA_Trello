using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Generic; 
using System.IO;       
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DA_Trello
{
    public class NoteEntry
    {
        public string ID { get; set; } //tạo ra ID riêng biệt cho từng thẻ
        public string Title { get; set; } //tiêu đề mỗi thẻ
        public string Body { get; set; } //nội dung của thẻ
        public DateTime CreationDate { get; set; } //ngày tạo thẻ
        public int Priority { get; set; } //độ ưu tiên của thẻ
        public string FilePath { get; set; } //lưu lại đường link chứa file
        //Constructor cho card
        public NoteEntry(string title, string body,int priority = 0, string filepath = "")
        {
            ID = Guid.NewGuid().ToString();
            Title = title;
            Body = body;
            this.CreationDate = DateTime.Now;
            Priority = priority;
            FilePath = filepath;

        }
        // Constructor mặc định (để JSON dùng)
        public NoteEntry() { }
    }
    public class NoteNode
    {
        // Lưu trữ dữ liệu tạo ở bước trước.
        public NoteEntry Data;

        // Con trỏ trỏ đến Node tiếp theo
        public NoteNode Next;

        // Con trỏ trỏ đến Node phía trước 
        //Doubly Linked List
        public NoteNode Prev;

        // Khi tạo một Node, nó chứa dữ liệu và chưa liên kết với bất kỳ Node nào.
        public NoteNode(NoteEntry data)
        {
            this.Data = data;
            // Ban đầu, Next và Prev đều là null.
            this.Next = null;
            this.Prev = null;
        }
    }
    public class TrelloList
    {
        public NoteNode head;
        public NoteNode tail;

        // Constructor đơn giản
        public TrelloList()
        {
            head = null;
            tail = null;
        }

        // Thuộc tính để lấy tất cả các ghi chú
        public List<NoteEntry> GetAllNotes()
        {
            var notes = new List<NoteEntry>();
            NoteNode current = head;
            while (current != null)
            {
                notes.Add(current.Data);
                current = current.Next;
            }
            return notes;
        }

        // Add
        public void Add(NoteEntry data)
        {
            NoteNode newNode = new NoteNode(data);
    
            if (head == null)
            {
                // Danh sách rỗng
                head = newNode;
                tail = newNode;
            }
            else
            {
                // 1. Node mới Prev = Tail cũ.
                newNode.Prev = tail;
                // 2. Tail cũ Next = Node mới.
                tail.Next = newNode;
                // 3. Tail mới = Node mới.
                tail = newNode;
            }
        }
        public bool Remove(string id)
        {
            if (head == null)
            {
                return false;
            }
            NoteNode current = head;
            NoteNode nodeToDelete = null;
            // 1. Giai đoạn TÌM KIẾM
            int index = 0;
            while (current != null)
            {
                // In ra ID của từng thằng trong list để so sánh
                string currentID = current.Data.ID;
              ;

                if (currentID == id)
                {
                    nodeToDelete = current;
                    break; // Tìm thấy thì dừng ngay
                }

                current = current.Next;
                index++;
            }

            // 2. Giai đoạn CẮT BỎ
            if (nodeToDelete == null)
            {
                return false;
            }

            try
            {
                // Case A: Xóa Head
                if (nodeToDelete == head)
                {
              
                    head = head.Next;
                    if (head != null) head.Prev = null;
                    else tail = null; // List rỗng
                }
                // Case B: Xóa Tail
                else if (nodeToDelete == tail)
                {
               
                    tail = tail.Prev;
                    if (tail != null) tail.Next = null;
                    else head = null;
                }
                // Case C: Xóa Giữa
                else
                {
               
                    nodeToDelete.Prev.Next = nodeToDelete.Next;
                    nodeToDelete.Next.Prev = nodeToDelete.Prev;
                }

                // Cleanup
                nodeToDelete.Next = null;
                nodeToDelete.Prev = null;

           
                return true;
            }
            catch (Exception ex)
            {
            
                return false;
            }
        }
        //Swap 2 node với nhau
        private void SwapData(NoteNode nodeA, NoteNode nodeB)
        {
            NoteEntry temp = nodeA.Data;
            nodeA.Data = nodeB.Data;
            nodeB.Data = temp;
        }
        public TrelloList SearchKeyWord(string keyword)
        {
            // 1. Tạo một danh sách liên kết MỚI để chứa kết quả
            TrelloList resultList = new TrelloList();

            if (head == null) return resultList;

            string key = keyword.Trim().ToLower();

            // 2. Duyệt danh sách GỐC
            NoteNode current = head;
            while (current != null)
            {
                string title = current.Data.Title.ToLower();
                string body = current.Data.Body.ToLower();

                // Kiểm tra khớp 
                if (IsContainsManual(title, key) || IsContainsManual(body, key))
                {
                    // 3. TÌM THẤY -> ADD VÀO DANH SÁCH KẾT QUẢ
                    resultList.Add(current.Data);
                }

                current = current.Next;
            }

            // 4. Trả về cả cái danh sách mới
            return resultList;
        }

        // Hàm bổ trợ cho thuật toán tìm chuỗi
        private bool IsContainsManual(string source, string target)
        {
            if (target.Length > source.Length) return false;
            for (int i = 0; i <= source.Length - target.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < target.Length; j++)
                {
                    if (source[i + j] != target[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match) return true; 
            }
            return false;
        }

        // Selection Sort
        public void SortByTitle()
        {
            if (head == null || head.Next == null) return;

            for (NoteNode current = head; current.Next != null; current = current.Next)
            {
                NoteNode maxNode = current;

                for (NoteNode scanner = current.Next; scanner != null; scanner = scanner.Next)
                {
                    if (string.Compare(scanner.Data.Title, maxNode.Data.Title, StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        maxNode = scanner;
                    }
                }

                if (maxNode != current)
                {
                    SwapData(current, maxNode);
                }
            }
        }

        // Insertion Sort
        public void SortByPriority()
        {
            if (head == null || head.Next == null) return;

            // Bắt đầu từ node thứ 2
            NoteNode current = head.Next;

            while (current != null)
            {
                // Lưu lại vị trí hiện tại 
                NoteNode nextNode = current.Next;
                NoteNode search = current;

                while (search.Prev != null && search.Prev.Data.Priority < search.Data.Priority)
                {
                    // Thì đổi chỗ 
                    SwapData(search, search.Prev);

                    // Lùi lại 1 bước để so sánh tiếp
                    search = search.Prev;
                }

                // Đi tiếp sang node kế tiếp của vòng lặp chính
                current = nextNode;
            }
        }

        // Bubble Sort: Nổi bọt
        public void SortByDate()
        {
            if (head == null || head.Next == null) return;

            bool swapped;
            do
            {
                swapped = false;
                NoteNode current = head;

                // Duyệt từ đầu đến sát đuôi
                while (current.Next != null)
                {
                    if (current.Data.CreationDate > current.Next.Data.CreationDate)
                    {
                        SwapData(current, current.Next);
                        swapped = true; 
                    }
                    current = current.Next;
                }
            } while (swapped);
        }

        public void Reverse()
        {
            if (head == null || head.Next == null)
                return; //Danh sách rỗng hoặc chỉ có một Node --> Không cần đảo ngược

            NoteNode current = head;
            NoteNode temp = null;

            while (current != null)
            {
                temp = current.Prev; 
                current.Prev = current.Next; 
                current.Next = temp; 
                current = current.Prev;
            }
            if (temp != null)
            {
                tail = head;
                head = temp.Prev;
            }
        }
        public void RemoveAll()
        {
            head = null;
            tail = null;
        }

        // --- PHẦN 1: HÀM LƯU (SAVE) ---
        public void SaveToFile(string filePath)
        {
            //Chuyển đổi Linked List sang List thường 
            List<NoteEntry> listToSave = new List<NoteEntry>();
            NoteNode current = head;
            while (current != null)
            {
                listToSave.Add(current.Data);
                current = current.Next;
            }

            //Biến thành chuỗi JSON
            string json = JsonConvert.SerializeObject(listToSave, Formatting.Indented);

            // Ghi đè xuống ổ cứng
            File.WriteAllText(filePath, json);
        }

        // --- PHẦN 2: HÀM TẢI (LOAD) ---
        public void LoadFromFile(string filePath)
        {
            //Kiểm tra file có tồn tại
            if (!File.Exists(filePath)) return;

            try
            {
                //Đọc nội dung file lên
                string json = File.ReadAllText(filePath);

                //Giải mã JSON về lại thành List thường
                List<NoteEntry> loadedList = JsonConvert.DeserializeObject<List<NoteEntry>>(json);

                //Xóa sạch danh sách hiện tại đi
                this.Clear();

                //Đổ dữ liệu từ List thường vào lại Linked List
                if (loadedList != null)
                {
                    foreach (var item in loadedList)
                    {
                        this.Add(item); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi đọc file: " + ex.Message);
            }
        }

        // --- PHẦN 3: HÀM DỌN DẸP (CLEAR) ---
        public void Clear()
        {
            head = null;
            tail = null;
        }
    }
}