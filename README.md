# StudyProcessManagement
#Font chữ : Time new roman
#Quy tắc đặt tên các nút:
#Quy tắc đặt tên File,Folder:ngôn ngữ tiếng anh, chữ cái in hoa đầu 
#Quy tắc đặt tên các nút: 
- phần hiển thị : tiếng việt
- Phần code : Tiếng anh
- Tên các nút, thành phần trong code(đều phải viết hoa chữ cái đầu) :
  - button: Btn+button's name
  - Textbox: Txt+name
  - Picture: Pt+name
  - Combobox: Cbx+name
  - ... anh e viết đặt thêm quy tắc các nút khác nếu có
- Khi tạo form mới đổi tên đưa form vô foder views đồng thời sửa NAMESPACE 2 file của form : name_form.cs,nameform[designer].cs
- Sau đó add thêm using file ở program.cs  
  QUY TRÌNH LÀM VIỆC:
  Chào team, chúng ta sẽ sử dụng quy trình Fork & Pull Request để làm việc nhóm. Đây là các bước thiết lập và quy trình làm việc hàng ngày.

Repo Gốc (Upstream) của chúng ta: https://github.com/phan-cao-huy/StudyProcessManagement

1. Thiết lập lần đầu (Chỉ làm 1 lần)
   Bước 1: Fork Repository
   Truy cập vào link Repo Gốc ở trên.

Nhấn nút "Fork" ở góc trên bên phải.

GitHub sẽ tạo một bản sao của repo này về tài khoản của bạn (ví dụ: github.com/TEN_THANH_VIEN/StudyProcessManagement).

Bước 2: Clone bản Fork về máy
Mở Terminal (hoặc Git Bash) trên máy tính của bạn và chạy lệnh sau. (Nhớ thay TEN_THANH_VIEN bằng username GitHub của bạn).

Bash

# KHÔNG clone từ repo gốc, hãy clone từ BẢN FORK của bạn

git clone https://github.com/TEN_THANH_VIEN/StudyProcessManagement.git

# Di chuyển vào thư mục dự án vừa clone

cd StudyProcessManagement
Bước 3: Kết nối với Repo Gốc (Upstream)
Bạn cần "báo" cho Git ở máy bạn biết Repo Gốc là ai, để sau này còn lấy cập nhật từ cả nhóm. Chúng ta gọi Repo Gốc là upstream.

Bash

# Thêm remote tên là "upstream" trỏ về repo gốc

git remote add upstream https://github.com/phan-cao-huy/StudyProcessManagement.git

# Kiểm tra lại xem đã thiết lập đúng chưa

git remote -v
Bạn sẽ thấy kết quả giống như vầy:

origin https://github.com/TEN_THANH_VIEN/StudyProcessManagement.git (fetch)
origin https://github.com/TEN_THANH_VIEN/StudyProcessManagement.git (push)
upstream https://github.com/phan-cao-huy/StudyProcessManagement.git (fetch)
upstream https://github.com/phan-cao-huy/StudyProcessManagement.git (push)
origin là bản fork của bạn (nơi bạn push code của MÌNH lên).

upstream là repo Gốc của nhóm (nơi bạn lấy code CỦA CẢ NHÓM về).

Xong! Bạn đã sẵn sàng làm việc.

2. Quy trình làm việc hàng ngày (Khi làm task mới)
   QUY TẮC VÀNG: Không bao giờ code trực tiếp trên branch main!

Bước 1: Cập nhật code mới nhất từ nhóm
Trước khi bắt đầu làm bất cứ thứ gì, hãy đảm bảo code ở máy bạn là mới nhất bằng cách kéo (pull) code từ Repo Gốc (upstream).

Bash

# Chuyển về branch main của bạn

git checkout main

# Kéo code mới nhất từ branch "main" của Repo Gốc ("upstream")

git pull upstream main

# (Tùy chọn) Đồng bộ branch main của bạn lên bản fork (origin)

git push origin main
Bước 2: Tạo branch mới cho Task
Luôn tạo một branch mới cho mỗi tính năng, task, hoặc bug fix. Đặt tên branch rõ ràng.

Bash

# Tạo và chuyển sang branch mới (ví dụ: làm tính năng đăng nhập)

git checkout -b feature/login

# Ví dụ khác:

# git checkout -b fix/header-bug

# git checkout -b docs/update-readme

Bước 3: Làm việc và Commit
Bây giờ bạn cứ code, sửa file, v.v. trên branch này. Sau khi làm xong một phần, hãy commit code.

Bash

# Thêm các file bạn đã thay đổi

git add .

# Commit với một tin nhắn rõ ràng

git commit -m "Feat: Hoan thanh chuc nang dang nhap co ban"
Bước 4: Push code lên bản Fork (Origin)
Khi bạn đã commit xong, hãy đẩy (push) branch mới này lên bản fork trên GitHub CỦA BẠN (origin).

Bash

# Đẩy branch "feature/login" của bạn lên "origin"

git push -u origin feature/login
Bước 5: Tạo Pull Request (PR)
Truy cập trang GitHub của bản fork của bạn (hoặc Repo Gốc, GitHub thường sẽ tự động gợi ý).

Bạn sẽ thấy một thanh màu vàng báo "Compare & pull request". Hãy nhấn vào đó.

Kiểm tra kỹ:

Base repository: phan-cao-huy/StudyProcessManagement

Base: main (hoặc branch chính của repo gốc)

Head repository: TEN_THANH_VIEN/StudyProcessManagement

Compare: feature/login (branch của bạn)

Viết tiêu đề và mô tả rõ ràng cho PR (bạn đã làm gì, sửa gì, tại sao...).

Nhấn "Create pull request".

Bước 6: Chờ Review
Leader (là tôi) sẽ nhận được thông báo, review code của bạn.

Nếu code ổn, tôi sẽ Merge vào Repo Gốc.

Nếu cần sửa, tôi sẽ comment trong PR. Bạn chỉ cần sửa code, commit thêm, và git push lên chính branch feature/login đó. PR sẽ tự động cập nhật.

Bước 7: Dọn dẹp (Sau khi PR đã được merge)
Sau khi Leader đã merge PR của bạn vào Repo Gốc, code của bạn đã an toàn. Giờ bạn có thể dọn dẹp:

Bash

# Quay về branch main

git checkout main

# (Tùy chọn) Xóa branch feature/login trên máy

git branch -d feature/login
Và lặp lại từ Bước 1 cho task tiếp theo!
