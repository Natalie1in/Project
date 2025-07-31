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