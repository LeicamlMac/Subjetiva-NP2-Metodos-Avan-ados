let cart = [];

function addToCart(id) {
  const item = menuItems.find(p => p.id === id);
  if (!item) return;

  const existing = cart.find(p => p.id === id);

  if (existing) {
    existing.quantity += 1;
  } else {
    cart.push({
      id: item.id,           // ← ESSA LINHA É OBRIGATÓRIA agora
      name: item.name,
      price: item.price,
      quantity: 1
    });
  }
  updateCart();
}

function removeFromCart(id) {
  const existing = cart.find(p => p.id === id);
  if (existing) {
    if (existing.quantity > 1) {
      existing.quantity -= 1;
    } else {
      cart = cart.filter(p => p.id !== id);
    }
  }
  updateCart();
}

function updateCart() {
  const cartItems = document.getElementById("cartItems");
  const cartCount = document.getElementById("cartCount");
  cartItems.innerHTML = "";

  let total = 0;
  cart.forEach(item => {
    total += item.price * item.quantity;

    const div = document.createElement("div");
    div.classList.add("cart-item");
    div.innerHTML = `
      <p><strong>${item.name}</strong> x${item.quantity}</p>
      <p>R$ ${(item.price * item.quantity).toFixed(2)}</p>
      <div class="cart-actions">
        <button onclick="removeFromCart(${item.id})">➖</button>
        <button onclick="addToCart(${item.id})">➕</button>
      </div>
    `;
    cartItems.appendChild(div);
  });

  if (cart.length === 0) {
    cartItems.innerHTML = "<p>Seu carrinho está vazio 😢</p>";
  }

  cartItems.innerHTML += `<hr><h3>Total: R$ ${total.toFixed(2)}</h3>`;
  cartCount.textContent = cart.reduce((acc, i) => acc + i.quantity, 0);
}
