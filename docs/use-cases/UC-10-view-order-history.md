# UC-10 – Wyświetlenie historii zamówień

## Opis

Użytkownik przegląda listę swoich wcześniejszych zamówień wraz ze statusami i szczegółami pozycji.

---

## Aktor

- Klient (użytkownik końcowy)

---

## Cel

Wyświetlenie historii zamówień użytkownika.

---

## Scenariusz główny

1. Użytkownik przechodzi do sekcji „Moje zamówienia”
2. Aplikacja wysyła żądanie `GET /api/orders`
3. System pobiera zamówienia użytkownika z Ordering
4. System zwraca listę zamówień z pozycjami i statusami
5. Aplikacja wyświetla historię zamówień

---

## Uwagi

- Lista zawiera snapshot danych produktów z momentu złożenia zamówienia
- Użytkownik widzi tylko własne zamówienia
