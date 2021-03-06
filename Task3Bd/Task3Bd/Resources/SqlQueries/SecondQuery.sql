SELECT DISTINCT PROJECT.NAME AS PROJECT, COUNT(TEST.NAME) AS TESTS_COUNT FROM UNION_REPORTING.PROJECT AS PROJECT 
JOIN 
(SELECT DISTINCT  NAME, PROJECT_ID
         FROM UNION_REPORTING.TEST) AS TEST
ON PROJECT.ID = TEST.PROJECT_ID
GROUP BY PROJECT.NAME
