# UC-08 – Złożenie zamówienia

## Opis

Użytkownik składa zamówienie na podstawie zawartości koszyka. System weryfikuje dane i tworzy zamówienie.

---

## Aktor

- Klient (użytkownik końcowy)

---

## Cel

Utworzenie zamówienia na podstawie koszyka użytkownika.

---

## Scenariusz główny

1. Użytkownik przechodzi do checkout
2. Aplikacja wysyła żądanie `POST /api/cart/checkout`
3. System pobiera zawartość koszyka
4. System pobiera dane produktów
5. System sprawdza dostępność (Stock)
6. System rezerwuje produkty (Stock)
7. System tworzy zamówienie
8. System publikuje zdarzenie `OrderPlaced`
9. System zwraca odpowiedź

---

## Scenariusze błędów

- Jeśli produkt nie jest dostępny w wymaganej ilości, system nie tworzy zamówienia i zwraca informację o braku stanu magazynowego.
- Jeśli rezerwacja produktów w Stock nie powiedzie się, system przerywa checkout i nie publikuje zdarzenia `OrderPlaced`.
- Jeśli aplikacja ponowi to samo żądanie checkout, system powinien obsłużyć je idempotentnie i nie utworzyć duplikatu zamówienia.

---

## Uwagi

- Zamówienie zapisuje snapshot danych (cena, nazwa)
