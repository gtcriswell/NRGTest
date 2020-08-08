USE NRGForm;
GO
CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'C0c@C0l@1';

SELECT name KeyName, 
    symmetric_key_id KeyID, 
    key_length KeyLength, 
    algorithm_desc KeyAlgorithm
FROM sys.symmetric_keys;

CREATE CERTIFICATE Certificate_SSN WITH SUBJECT = 'Secure SSN';

SELECT name CertName, 
    certificate_id CertID, 
    pvt_key_encryption_type_desc EncryptType, 
    issuer_name Issuer
FROM sys.certificates;

CREATE SYMMETRIC KEY SymKey_SSN WITH ALGORITHM = AES_256 ENCRYPTION BY CERTIFICATE Certificate_SSN;

SELECT name KeyName, 
    symmetric_key_id KeyID, 
    key_length KeyLength, 
    algorithm_desc KeyAlgorithm
FROM sys.symmetric_keys;

