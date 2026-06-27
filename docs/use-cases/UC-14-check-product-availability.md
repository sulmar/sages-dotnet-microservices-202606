# UC-14 – Sprawdzenie dostępności produktu

## Opis

System sprawdza, czy produkt jest dostępny w wymaganej ilości.

---

## Aktor

- System (Ordering)

---

## Cel

Weryfikacja dostępności produktu przed złożeniem zamówienia.

---

## Scenariusz główny

1. System otrzymuje żądanie sprawdzenia dostępności
2. System sprawdza stan magazynowy (Stock, gRPC)
3. System zwraca informację o dostępności

---

## Scenariusze błędów

- Jeśli produkt nie istnieje, Stock zwraca informację o braku produktu.
- Jeśli dostępna ilość jest mniejsza niż wymagana, Stock zwraca brak dostępności wraz z aktualną ilością możliwą do zamówienia.
- Jeśli wywołanie gRPC do Stock nie powiedzie się, Ordering przerywa proces i nie przechodzi do rezerwacji.
