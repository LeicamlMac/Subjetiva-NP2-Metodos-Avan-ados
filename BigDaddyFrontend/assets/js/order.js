document.getElementById("finalizeOrder").addEventListener("click", async () => {
  const table = document.getElementById("tableNumber").value.trim();
  const obs = document.getElementById("obs").value.trim();

  if (!table || cart.length === 0) {
    alert("Preencha a mesa e adicione itens!");
    return;
  }

  const payload = {
    tableNumber: Number(table),
    observations: obs || null,
    items: cart.map(i => ({
      id: i.id || 0,
      name: i.name,
      quantity: i.quantity,
      price: Number(i.price)
    }))
  };

  console.log("Enviando para o backend:", payload); 

  try {
    const res = await fetch("http://localhost:5249/api/Order", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(payload)
    });

    const texto = await res.text();
    if (res.ok) {
      alert("PEDIDO ENVIADO COM SUCESSO! ID: " + (JSON.parse(texto).orderId || "OK"));
      cart = [];
      updateCart();
      document.getElementById("tableNumber").value = "";
      document.getElementById("obs").value = "";
    } else {
      alert("ERRO " + res.status + "\n" + texto);
    }
  } catch (e) {
    alert("Backend não está rodando!");
  }
});