# UC-12 – Zwrot płatności

## Opis

System zwraca płatność za anulowane lub zwrócone zamówienie. Proces uruchamiany jest asynchronicznie po anulowaniu zamówienia.

---

## Aktor

- System (Payment)

---

## Cel

Zwrócenie środków użytkownikowi i aktualizacja statusu płatności.

---

## Scenariusz główny

1. System odbiera zdarzenie `OrderCancelled`
2. System weryfikuje, czy zamówienie było opłacone
3. System inicjuje zwrot płatności
4. System publikuje zdarzenie `PaymentRefunded`
5. System aktualizuje status płatności

---

## Scenariusze błędów

- Jeśli zamówienie nie było opłacone, system nie inicjuje zwrotu i zapisuje decyzję biznesową.
- Jeśli operator płatności odrzuci zwrot, system zapisuje błąd i oznacza zwrot do ponowienia lub ręcznej obsługi.
- Jeśli system odbierze duplikat zdarzenia `OrderCancelled`, nie powinien zlecać drugiego zwrotu dla tej samej płatności.
- Zwrot powinien być idempotentny na podstawie identyfikatora płatności lub identyfikatora refundu.

---

## Uwagi

- Zwrot dotyczy tylko zamówień z potwierdzoną płatnością
- Komunikacja asynchroniczna (Redis Streams)
- Możliwe opóźnienia (eventual consistency)
