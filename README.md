# Film theater

This is a university laboratory work for [Web application design](https://uais.cr.ktu.lt/ktuis/stp_report_ects.mdl_ml?p_kodas=T120B165&p_year=2021&p_lang=LT&p_stp_id=8065) module.

The project uses **.NET 5.0**, **React.JS** and **SQL**.  

The project implements **RESTful API** architecture. 

The system uses 3 related application domain objects: **Theater** -> **Room** -> **Session**. 

# General project requirements:
1. The interface must implement at least 5 API methods for at least 3 related application domain objects. Each object must have: 
    - 4 CRUD methods;
    - a method returning a list.
2. The project must use a database.
3. Project users should have at least 3 roles (guest, member, administrator).
4. Authentication with OAUTH2 or JWT must be implemented (use JWT to choose the appropriate token update strategy).
