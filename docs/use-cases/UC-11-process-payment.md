# UC-11 – Opłacenie zamówienia

## Opis

System przetwarza płatność dla złożonego zamówienia na podstawie zdarzenia.

---

## Aktor

- System (Payment)

---

## Cel

Przetworzenie płatności i aktualizacja statusu zamówienia.

---

## Scenariusz główny

1. System odbiera zdarzenie `OrderPlaced`
2. System przetwarza płatność
3. System publikuje zdarzenie `PaymentCompleted`
4. System aktualizuje status zamówienia

---

## Scenariusze błędów

- Jeśli płatność zostanie odrzucona, system zapisuje status nieudanej płatności i publikuje zdarzenie `PaymentFailed`.
- Jeśli system odbierze duplikat zdarzenia `OrderPlaced`, nie powinien pobierać płatności ponownie.
- Przetwarzanie płatności powinno być idempotentne na podstawie identyfikatora zamówienia lub identyfikatora zdarzenia.

---

## Uwagi

- Brak bezpośredniego wywołania z Ordering (asynchronicznie)
- Payment działa niezależnie od Ordering
- Możliwe opóźnienia (eventual consistency)
