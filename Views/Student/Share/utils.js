// Hàm bất đồng bộ để tải nội dung HTML từ một tệp cục bộ


// Hàm tải sidebar


// Hàm gửi thông điệp điều hướng về C# (Định nghĩa trong utils.js)
function navigateTo(targetFileName) {
    window.chrome.webview.postMessage(targetFileName);
}

function logout() {
    if (confirm("Bạn có chắc muốn đăng xuất?")) {
        window.chrome.webview.postMessage("LOGOUT");
    }
}