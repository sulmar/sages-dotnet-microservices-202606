# UC-09 – Anulowanie zamówienia

## Opis

Użytkownik anuluje złożone zamówienie, które nie zostało jeszcze zrealizowane. System aktualizuje status zamówienia i zwalnia zarezerowane produkty.

---

## Aktor

- Klient (użytkownik końcowy)

---

## Cel

Anulowanie zamówienia i przywrócenie dostępności produktów.

---

## Scenariusz główny

1. Użytkownik otwiera historię zamówień
2. Użytkownik wybiera zamówienie do anulowania
3. Aplikacja wysyła żądanie `POST /api/orders/{id}/cancel`
4. System weryfikuje, czy zamówienie można anulować
5. System anuluje rezerwację produktów (Stock)
6. System aktualizuje status zamówienia
7. System publikuje zdarzenie `OrderCancelled`
8. System zwraca odpowiedź

---

## Uwagi

- Anulowanie możliwe tylko dla określonych statusów zamówienia
- W przypadku opłaconego zamówienia może być wymagany zwrot płatności (UC-12)
