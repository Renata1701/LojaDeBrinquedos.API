SELECT DATABASE();
SHOW TABLES;
SELECT * FROM categorias;
INSERT INTO produtos (nome, descricao, preco, categoria_id, estoque, fornecedor_id)
VALUES
  ('Carrinho Controle Remoto', 'Carrinho com controle remoto rápido', 150.00, 1, 10, 1),
  ('Boneca Princesa', 'Boneca com vestido rosa e acessórios', 89.90, 2, 25, 2),
  ('Jogo Educativo ABC', 'Jogo que ensina o alfabeto', 49.99, 3, 40, 1);

INSERT INTO produtos (nome, descricao, preco, categoria_id, estoque, fornecedor_id)
VALUES ('Carrinho de Controle Remoto', 'Carrinho rápido e resistente', 150.00, 1, 10, 1);
SELECT p.id, p.nome, p.descricao, p.preco, c.nome AS categoria_nome, p.estoque
FROM produtos p
JOIN categorias c ON p.categoria_id = c.id;
ALTER TABLE categorias
ADD CONSTRAINT unique_nome UNIQUE (nome);
