document.getElementById("finalizeOrder").addEventListener("click", () => {
  const table = document.getElementById("tableNumber").value;
  const obs = document.getElementById("obs").value;

  if (!table) {
    alert("Por favor, informe o número da mesa.");
    return;
  }

  if (cart.length === 0) {
    alert("O carrinho está vazio!");
    return;
  }

  const order = {
    table,
    obs,
    items: cart.map(i => ({ name: i.name, quantity: i.quantity, price: i.price })),
    total: cart.reduce((sum, i) => sum + i.price * i.quantity, 0)
  };

  console.log("Pedido finalizado:", order);
  alert("✅ Pedido enviado com sucesso!\n\n(Em breve será integrado ao backend)");
  
  cart = [];
  updateCart();
  document.getElementById("tableNumber").value = "";
  document.getElementById("obs").value = "";
});
