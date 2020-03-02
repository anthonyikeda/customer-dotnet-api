create database customers;
create user customer_admin with password 'letmein';
grant all on database customers to customer_admin;
