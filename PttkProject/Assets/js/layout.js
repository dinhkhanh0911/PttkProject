$(document).ready(function () {
    setMenu()
});

function setMenu() {
    $.ajax({
        type: 'get',
        url: '/trang-chu/lay-coockie',
        datatype: 'json',
        success: function (data) {
            var elementPC = document.querySelector('#pc-body-navbar');
            var elementMB = document.querySelector('#mobile-body-navbar');
            var menuUser = `

                    <li class="nav-item">
                        <a href="/trang-chu/index" class="nav-item__link nav-item__home-page">
                            <h6>Trang chủ</h6>
                        </a>
                    </li>
                    <div class="border-bottom body-navbar__border-bottom"></div>
                            
                    <li class="nav-item">
                        <a href="/benh-nhan/index" class="nav-item__link">
                            <i class="fa fa-plus-circle" aria-hidden="true"></i>
                            <span>Quản lý bệnh nhân</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="/phong-benh/index" class="nav-item__link">
                            <i class="fa fa-pencil-square" aria-hidden="true"></i>
                            <span>Quản lý phòng bệnh</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="/nhan-vien-y-te/index" class="nav-item__link">
                            <i class="fa fa-trash-o" aria-hidden="true"></i>
                            <span>Quản lý nhân viên y tế</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="/thong-ke/index" class="nav-item__link">
                            <i class="fa fa-search" aria-hidden="true"></i>
                            <span>Thống kê</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-item__link" href="/xuat-du-lieu/index">
                            <i class="fa fa-search" aria-hidden="true"></i>
                            <span>Xuất dữ liệu</span>
                        </a>
                    </li>
                    <div class="border-bottom body-navbar__border-bottom"></div>
                    <li class="nav-item">
                        <a href="/dang-nhap/dang-xuat" class="nav-item__link">
                            <i class="fa fa-search" aria-hidden="true"></i>
                            <span>Đăng xuất</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="../User/ChangePassword" class="nav-item__link">
                            <i class="fa fa-search" aria-hidden="true"></i>
                            <span>Đổi mật khẩu</span>
                        </a>
                    </li>
                `
            var menuAdmin = `

                    <li class="nav-item">
                        <a href="/trang-chu/index" class="nav-item__link nav-item__home-page">
                            <h6>Trang chủ</h6>
                        </a>
                    </li>
                    <div class="border-bottom body-navbar__border-bottom"></div>
                            
                    <li class="nav-item">
                        <a href="/nguoi-dung/index" class="nav-item__link">
                            <i class="fa fa-plus-circle" aria-hidden="true"></i>
                            <span>Quản lý người dùng</span>
                        </a>
                    </li>
                    <div class="border-bottom body-navbar__border-bottom"></div>
                    <li class="nav-item">
                        <a href="/dang-nhap/dang-xuat" class="nav-item__link">
                            <i class="fa fa-search" aria-hidden="true"></i>
                            <span>Đăng xuất</span>
                        </a>
                    </li>
                    <li class="nav-item">
                        <a href="../User/ChangePassword" class="nav-item__link">
                            <i class="fa fa-search" aria-hidden="true"></i>
                            <span>Đổi mật khẩu</span>
                        </a>
                    </li>
                `
            if (data.code == 1) {
                elementPC.innerHTML = menuAdmin
                elementMB.innerHTML = menuAdmin
            }
            else if (data.code == 2) {
                elementPC.innerHTML = menuUser
                elementMB.innerHTML = menuUser
            }
        }
    })
}