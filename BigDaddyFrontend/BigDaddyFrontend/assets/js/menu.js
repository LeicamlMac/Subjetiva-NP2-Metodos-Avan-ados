const menuItems = [
  {
    id: 1,
    name: "Burger Clássico Duplo",
    description: "Pão brioche, carne dupla 110g e creme cheddar.",
    price: 29.90,
    image: "https://static.ifood-static.com.br/image/upload/t_medium/pratos/83ae98f8-d4db-4506-b931-52b0eab20724/202204241643_6H40_i.jpg"
  },
  {
    id: 2,
    name: "Burger Supreme",
    description: "Pão de brioche, blend 200g, cheddar, cebola caramelizada, bacon e maionese defumada.",
    price: 34.90,
    image: "https://static.ifood-static.com.br/image/upload/t_medium/pratos/83ae98f8-d4db-4506-b931-52b0eab20724/202204241634_FM2D_i.jpg"
  },
  {
    id: 3,
    name: "Combo Clássico",
    description: "Pão brioche, carne dupla 110g, creme cheddar + fritas + suco de laranja.",
    price: 39.90,
    image: "https://static.ifood-static.com.br/image/upload/t_medium/pratos/83ae98f8-d4db-4506-b931-52b0eab20724/202204241711_8LEF_i.jpg"
  },
  {
    id: 4,
    name: "Combo Supreme",
    description: "Pão brioche, blend 200g, cheddar, cebola caramelizada, bacon, maionese defumada + fritas + suco.",
    price: 44.90,
    image: "https://static.ifood-static.com.br/image/upload/t_medium/pratos/83ae98f8-d4db-4506-b931-52b0eab20724/202204241706_7MT3_i.jpg"
  }
];

const menuContainer = document.getElementById("menu");

menuItems.forEach(item => {
  const div = document.createElement("div");
  div.classList.add("menu-item");
  div.innerHTML = `
    <img src="${item.image}" alt="${item.name}">
    <h3>${item.name}</h3>
    <p>${item.description}</p>
    <p><strong>R$ ${item.price.toFixed(2)}</strong></p>
    <button onclick="addToCart(${item.id})">Adicionar</button>
  `;
  menuContainer.appendChild(div);
});
