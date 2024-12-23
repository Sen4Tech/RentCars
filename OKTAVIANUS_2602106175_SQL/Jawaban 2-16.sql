
-------------------
--> SOAL NO.2
-------------------
SELECT COUNT(*) as total_car
FROM rentcars.dbo.MsCar
WHERE status = 1;

-------------------
--> SOAL NO.3
-------------------
SELECT AVG(price_per_day) as rata_rata_harga
FROM rentcars.dbo.MsCar;
-------------------
--> SOAL NO.4
-------------------
SELECT COUNT(*) as total_customer
FROM rentcars.dbo.MsCustomer;

-------------------
--> SOAL NO.5
-------------------
SELECT Car_id, name, model, [year], license_plate, number_of_car_seats, transmission, price_per_day, status
FROM rentcars.dbo.MsCar
WHERE price_per_day = (SELECT MAX(price_per_day) FROM rentcars.dbo.MsCar);

-------------------
--> SOAL NO.6
-------------------
SELECT SUM(cost) as biaya_total_maintenance
FROM rentcars.dbo.TrMaintenance;

-------------------
--> SOAL NO.7
-------------------
SELECT tr.customer_id, mc.name, 
       COUNT(*) as rental_count
FROM rentcars.dbo.TrRental tr
JOIN rentcars.dbo.MsCustomer mc ON tr.customer_id = mc.customer_id
GROUP BY tr.customer_id, mc.name
ORDER BY tr.customer_id;

-------------------
--> SOAL NO.8
-------------------
SELECT car_id,
       AVG(total_price) as average_rental_price
FROM rentcars.dbo.TrRental
GROUP BY car_id
ORDER BY car_id;

-------------------
--> SOAL NO.9
-------------------
SELECT mc.Car_id, mc.name,
       COUNT(tm.maintenance_id) as maintenance_count
FROM rentcars.dbo.MsCar mc
LEFT JOIN rentcars.dbo.TrMaintenance tm ON mc.Car_id = tm.car_id
GROUP BY mc.Car_id, mc.name
ORDER BY mc.Car_id;

-------------------
--> SOAL NO.10
-------------------
SELECT car_id,
       COUNT(*) as rental_count
FROM rentcars.dbo.TrRental
GROUP BY car_id
HAVING COUNT(*) >= 6
ORDER BY COUNT(*) DESC;

-------------------
--> SOAL NO.11
-------------------
SELECT [year], 
       COUNT(*) as car_count
FROM rentcars.dbo.MsCar
GROUP BY [year]
ORDER BY [year];

-------------------
--> SOAL NO.12
-------------------
SELECT employee_id,
       SUM(cost) as total_cost
FROM rentcars.dbo.TrMaintenance
GROUP BY employee_id
ORDER BY employee_id;

-------------------
--> SOAL NO.13
-------------------
SELECT customer_id, 
       COUNT(*) as rental_count
FROM rentcars.dbo.TrRental
GROUP BY customer_id
HAVING COUNT(*) > 3
ORDER BY customer_id;

-------------------
--> SOAL NO.14
-------------------
SELECT payment_method,
       COUNT(*) as payment_count
FROM rentcars.dbo.TrPayment
GROUP BY payment_method
ORDER BY payment_method;

-------------------
--> SOAL NO.15
-------------------
SELECT r.customer_id,
       mc.name,
       CAST(SUM(r.total_price) AS DECIMAL(10,2)) as total_payment
FROM rentcars.dbo.TrRental r
JOIN rentcars.dbo.MsCustomer mc ON r.customer_id = mc.Customer_id
GROUP BY r.customer_id, mc.name
ORDER BY total_payment DESC
OFFSET 0 ROWS
FETCH NEXT 3 ROWS ONLY;

-------------------
--> SOAL NO.16
-------------------
SELECT 
    tm.cost as cost,
    mc.name as car_name,
    tm.description,
    tm.maintenance_date
FROM TrMaintenance tm WITH (nolock) 
JOIN MsCar mc ON tm.Car_id = mc.Car_id
ORDER BY tm.maintenance_date ASC;

