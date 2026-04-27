select
    first_name,
    last_name,
    email
from customer
WHERE email LIKE '%@sakilacustomer.org'
order by last_name;
