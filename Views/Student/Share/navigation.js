/**
 * ⭐ HÀM ĐIỀU HƯỚNG THỐNG NHẤT CHO TẤT CẢ TRANG ⭐
 * Gửi message tới C# WebView2 để xử lý điều hướng
 */
function navigateTo(target) {
    // target values handled by C#: INFORMATION, MY_COURSES, DISCOVER, ASSIGNMENT, GRADES, CONTENT, LOGOUT
    try {
        if (window.chrome && window.chrome.webview) {
            window.chrome.webview.postMessage(target);
        } else {
            // Browser fallback: map to local html paths
            var urls = {
                'INFORMATION': '../information/studient-information.html',
                'MY_COURSES': '../courses/student-my-courses.html',
                'DISCOVER': '../discover/student-discover.html',
                'ASSIGNMENT': '../assignments/student-assignments.html',
                'GRADES': '../grades/student-grades.html',
                'CONTENT': '../content/student-content.html',
                'LOGOUT': '../../Login/login.html'
            };
            if (urls[target]) {
                window.location.href = urls[target];
            } else {
                console.warn('[NAV] Unknown target:', target);
            }
        }
    } catch (e) {
        console.error('[NAV] Error sending navigation message:', e);
    }
}

function navigateToAssignment() {
    navigateTo('ASSIGNMENT');
}

/**
 * ⭐ HÀM ĐĂNG XUẤT ⭐
 */
function logout() {
    if (confirm('Bạn có chắc muốn đăng xuất?')) {
        navigateTo('LOGOUT');
    }
}

/**
 * ⭐ HÀM LOAD SIDEBAR (Nếu cần load động) ⭐
 */
function loadSidebar() {
    var placeholder = document.getElementById('sidebar-placeholder');
    if (!placeholder) return;
    fetch('../Share/student-sidebar.html')
        .then(function (r) { return r.text(); })
        .then(function (html) {
            placeholder.innerHTML = html;
        })
        .catch(function (err) {
            console.error('[SIDEBAR] load error', err);
        });
}

// Tự động load sidebar khi trang được tải
document.addEventListener('DOMContentLoaded', loadSidebar);

/* file: index.html */
/* <!-- Thêm vào cuối trước </body> -->
<script src="../Share/navigation.js"></script> */

private void CoreWebView2_WebMessageReceived(object sender,
    Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
{
    string message = e.TryGetWebMessageAsString();
    string targetRelativePath = null;

    // ✅ KIỂM TRA: Tất cả case này có tồn tại không?
    if (message == "LOGOUT")
    {
        // Xử lý logout
        return;
    }
    else if (message == "INFORMATION")
    {
        targetRelativePath = Path.Combine("Views", "Student", "information", "studient-information.html");
    }
    else if (message == "MY_COURSES")
    {
        targetRelativePath = Path.Combine("Views", "Student", "courses", "student-my-courses.html");
    }
    else if (message == "ASSIGNMENT")
    {
        targetRelativePath = Path.Combine("Views", "Student", "assignments", "student-assignments.html");
    }
    else if (message == "GRADES")
    {
        targetRelativePath = Path.Combine("Views", "Student", "grades", "student-grades.html");
    }
    else if (message == "CONTENT")
    {
        targetRelativePath = Path.Combine("Views", "Student", "content", "student-content.html");
    }
    else if (message == "DISCOVER")
    {
        targetRelativePath = Path.Combine("Views", "Student", "discover", "student-discover.html");
    }
    
    // Sau đó điều hướng...
}
    <script src="../Share/navigation.js"></script>
</body>
</html>