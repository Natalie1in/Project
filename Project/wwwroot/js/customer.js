function updateQty(orderId, productId) {
    const inputId = `qty-${orderId}-${productId}`;
    const quantity = document.getElementById(inputId).value;

    axios.post('/Customer/UpdateProductQuantity', {
        orderId: orderId,
        productId: productId,
        quantity: parseInt(quantity)
    }).then(res => {
        alert(res.data.message);
    }).catch(err => {
        alert("更新失敗：" + err.response?.data || err.message);
    });
}

async function deleteOrder(orderId) {
    if (!confirm(`確定要刪除訂單編號 ${orderId} 嗎？`)) return;

    try {
        
        const response = await axios.post('/Customer/DeleteOrder', orderId,{
            headers: { 'Content-Type': 'application/json' }
        });
        console.log(orderId);
        if (response.data.success) {
            alert("訂單已刪除");
            location.reload();
        } else {
            alert("刪除失敗");
        }
    } catch (error) {
        console.error(error);
        alert("刪除發生錯誤");
    }
}