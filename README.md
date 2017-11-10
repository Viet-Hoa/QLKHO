# QLKHO
Đồ án HTTTDN quản lý kho điện máy
chức năng:
đăng nhập
thêm sp, sửa sp(trừ số lượng), vô hiệu sp(TINHTRANG ban đầu là true sửa thành false)
thêm sưả nhà cung cấp,cửa hàng(trừ TIENNO)
thêm sửa xoá đặt hàng, ct đặt hàng (TINHTRANG ban đầu là false)
thêm sửa xoá yêu cầu xuất, ct yêu cầu (TINHTRANG ban đầu là false)
thêm phiếu nhập, ct phiếu nhập dựa trên đặt hàng(load ra ct đặt hàng lên bảng tạm, sửa đổi rồi lưu thành ct phiếu nhập, TINHTRANG đăt hàng thành true)
thêm phiếu xuất, ct phiếu xuất dựa trên yêu cầu xuất (load ra ct yêu cầu lên bảng tạm, sửa đổi rồi lưu thành ct phiếu xuất, TINHTRANG yêu cầu thành true)
thêm xoá thu chi
thêm thống kê tồn kho tự động load ra danh sách sp hiện tại lên bảng tạm để user sửa số lượng nhấn lưu mới lưu vào database
nhập ảnh hưởng tăng số lượng, thai đổi đơn giá bình quân sp và tăng nợ nhà cung cấp
xuất ảnh hưởng giảm số lượng sản phẩm và tăng nợ cửa hàng
thu làm giảm nợ cửa hàng
chi làm giảm nợ nhà cung cấp
