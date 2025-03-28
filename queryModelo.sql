-- Inserta el examen (si no existe previamente)

DECLARE @id_exam INT;

INSERT INTO exams (id_subject, year, semestre, type, week)
VALUES (4, 2012, NULL, 'B', 2);

SET @id_exam = SCOPE_IDENTITY();

-- Pregunta 1
DECLARE @id_question_1 INT;
DECLARE @n_question INT = 1;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'La variable equilibrio emocional de la Gráfica 1:',
NULL,
'La variable equilibrio emocional está medida a nivel ordinal con tres categorías; bajo (1), medio (2) y alto (3)'
);

SET @id_question_1 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_1, 'A', 'es cualitativa', 0),
(@id_question_1, 'B', 'es cuantitativa discreta', 0),
(@id_question_1, 'C', 'está medida a nivel ordinal', 1);

-- Pregunta 2
DECLARE @id_question_2 INT;
SET @n_question = 2;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Comparando el número de hijos con equilibrio emocional medio y alto en la Gráfica 1, observamos que:',
NULL,
'Nº de hijos con equilibrio emocional medio: 120 + 100 = 220\nNº de hijos con equilibrio emocional alto: 210 + 50 = 260\n220 < 260'
);

SET @id_question_2 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_2, 'A', 'la frecuencia es menor en los primeros', 1),
(@id_question_2, 'B', 'la frecuencia es mayor en los primeros', 0),
(@id_question_2, 'C', 'las frecuencias son iguales', 0);

-- Pregunta 3
DECLARE @id_question_3 INT;
SET @n_question = 3;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Respecto a la Tabla 1, los límites exactos del cuarto intervalo (empezando desde abajo) y la frecuencia absoluta acumulada correspondiente a dicho intervalo son:',
NULL,
'Frecuencia absoluta acumulada: 0,25 x 1000 = 250'
);

SET @id_question_3 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_3, 'A', '18,5 - 24,5 y 160', 0),
(@id_question_3, 'B', '18,5 - 24,5 y 250', 1),
(@id_question_3, 'C', '18,5 - 24,5 y 500', 0);

-- Pregunta 4
DECLARE @id_question_4 INT;
SET @n_question = 4;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Respecto a la Tabla 1, la distribución:',
NULL,
NULL
);

SET @id_question_4 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_4, 'A', 'no tiene moda', 0),
(@id_question_4, 'B', 'es unimodal', 0),
(@id_question_4, 'C', 'es bimodal', 1);

-- Pregunta 5
DECLARE @id_question_5 INT;
SET @n_question = 5;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'¿Qué percentil corresponde a X = 24,5 en la distribución de la Tabla 1?',
NULL,
NULL
);

SET @id_question_5 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_5, 'A', 'P10', 0),
(@id_question_5, 'B', 'P25', 1),
(@id_question_5, 'C', 'P50', 0);

-- Pregunta 6
DECLARE @id_question_6 INT;
SET @n_question = 6;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Respecto a la Tabla 1, la amplitud semi-intercuartil de la distribución vale:',
NULL,
NULL
);

SET @id_question_6 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_6, 'A', '4', 0),
(@id_question_6, 'B', '6', 1),
(@id_question_6, 'C', '8', 0);

-- Pregunta 7
DECLARE @id_question_7 INT;
SET @n_question = 7;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Respecto a la distribución de la Tabla 1, ¿puede calcularse el índice de asimetría de Pearson?',
NULL,
'La obtención del índice de asimetría de Pearson requiere que la distribución sea unimodal.'
);

SET @id_question_7 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_7, 'A', 'no, porque es bimodal', 0),
(@id_question_7, 'B', 'no, porque no tiene moda', 0),
(@id_question_7, 'C', 'sí, porque es unimodal', 1);

-- Pregunta 8
DECLARE @id_question_8 INT;
SET @n_question = 8;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Un adolescente ha obtenido en el test de adaptación social una puntuación X = 100. Si µ = 120 y σ = 10, esto indica que:',
NULL,
NULL
);

SET @id_question_8 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_8, 'A', 'una desviación típica por encima de la media', 0),
(@id_question_8, 'B', 'dos desviaciones típicas por encima de la media', 0),
(@id_question_8, 'C', 'dos desviaciones típicas por debajo de la media', 1);

-- Pregunta 9
DECLARE @id_question_9 INT;
SET @n_question = 9;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Respecto a la Gráfica 1, si calculamos X² = 201,53, el coeficiente de contingencia está próximo a:',
NULL,
NULL
);

SET @id_question_9 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_9, 'A', '0', 0),
(@id_question_9, 'B', '0,5', 1),
(@id_question_9, 'C', '1', 0);

-- Pregunta 10
DECLARE @id_question_10 INT;
SET @n_question = 10;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Con los datos de la Tabla 2, si el estrés del entorno familiar de un adolescente es X = 9, la agresividad pronosticada es:',
NULL,
NULL
);

SET @id_question_10 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_10, 'A', '7', 0),
(@id_question_10, 'B', '7,4', 0),
(@id_question_10, 'C', '9,2', 1);

-- Pregunta 11
DECLARE @id_question_11 INT;
SET @n_question = 11;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Respecto a la Tabla 2, SY vale:',
NULL,
NULL
);

SET @id_question_11 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_11, 'A', '1,5', 1),
(@id_question_11, 'B', '2,03', 0),
(@id_question_11, 'C', '4,13', 0);

-- Pregunta 12
DECLARE @id_question_12 INT;
SET @n_question = 12;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Con los datos de la Gráfica 1, la probabilidad de que un hijo tenga equilibrio emocional bajo es:',
NULL,
NULL
);

SET @id_question_12 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_12, 'A', '0,175', 0),
(@id_question_12, 'B', '0,40', 1),
(@id_question_12, 'C', '0,80', 0);

-- Pregunta 13
DECLARE @id_question_13 INT;
SET @n_question = 13;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Con los datos de la Gráfica 1, la probabilidad de equilibrio emocional alto:',
NULL,
NULL
);

SET @id_question_13 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_13, 'A', 'es mayor en el grupo de parejas divorciadas', 0),
(@id_question_13, 'B', 'es menor en el grupo de parejas divorciadas', 1),
(@id_question_13, 'C', 'es la misma en ambos grupos', 0);

-- Pregunta 14
DECLARE @id_question_14 INT;
SET @n_question = 14;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'El espacio muestral E = {cara cara; cara cruz; cruz cara; cruz cruz} corresponde al experimento de lanzar al aire una moneda:',
NULL,
'Al lanzar una moneda dos veces al aire, puede ocurrir: cara en los dos lanzamientos, cara en el primer lanzamiento y cruz en el segundo, cruz en el primer lanzamiento y cara en el segundo, cruz en los dos lanzamientos.'
);

SET @id_question_14 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_14, 'A', 'dos veces', 1),
(@id_question_14, 'B', 'cuatro veces', 0),
(@id_question_14, 'C', 'ocho veces', 0);

-- Pregunta 15
DECLARE @id_question_15 INT;
SET @n_question = 15;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Respecto al espacio muestral del ejercicio 14, el número de casos posibles es:',
NULL,
'Hay 4 casos posibles, los 4 casos indicados en el espacio muestral: cara cara; cara cruz; cruz cara; cruz cruz'
);

SET @id_question_15 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_15, 'A', '2', 0),
(@id_question_15, 'B', '4', 1),
(@id_question_15, 'C', '8', 0);

-- Pregunta 16
DECLARE @id_question_16 INT;
SET @n_question = 16;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Respecto al espacio muestral del ejercicio 14, si definimos una variable aleatoria X como número de caras obtenidas, la media de X vale:',
NULL,
NULL
);

SET @id_question_16 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_16, 'A', '0,5', 0),
(@id_question_16, 'B', '0,75', 0),
(@id_question_16, 'C', '1', 1);

-- Pregunta 17
DECLARE @id_question_17 INT;
SET @n_question = 17;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'En una consulta con 80% de pacientes depresivos varones, ¿cuál es la probabilidad de que 4 de 10 pacientes elegidos sean mujeres?',
NULL,
'Tabla I de la binomial con n = 10, x = 4 y p = 0,2'
);

SET @id_question_17 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_17, 'A', '0,0881', 1),
(@id_question_17, 'B', '0,20', 0),
(@id_question_17, 'C', '0,9672', 0);

-- Pregunta 18
DECLARE @id_question_18 INT;
SET @n_question = 18;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Una variable X se distribuye según una Binomial con n = 100 y p = 0,5. La P(X ≤ 54) es igual a:',
NULL,
NULL
);

SET @id_question_18 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_18, 'A', '0,5398', 0),
(@id_question_18, 'B', '0,6664', 0),
(@id_question_18, 'C', '0,8159', 1);

-- Pregunta 19
DECLARE @id_question_19 INT;
SET @n_question = 19;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Respecto a la Gráfica 2, la desviación típica de la distribución de la variable X:',
NULL,
NULL
);

SET @id_question_19 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_19, 'A', 'vale 1', 0),
(@id_question_19, 'B', 'vale 10', 1),
(@id_question_19, 'C', 'no se puede calcular', 0);

-- Pregunta 20
DECLARE @id_question_20 INT;
SET @n_question = 20;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Respecto a la Gráfica 2, la probabilidad de obtener un valor inferior a µ = 80:',
NULL,
NULL
);

SET @id_question_20 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_20, 'A', 'vale 0', 0),
(@id_question_20, 'B', 'vale 0,5', 1),
(@id_question_20, 'C', 'no se puede calcular', 0);

-- Pregunta 21
DECLARE @id_question_21 INT;
SET @n_question = 21;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Respecto a la media de la distribución t de Student:',
NULL,
NULL
);

SET @id_question_21 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_21, 'A', 'cuanto mayor es el número de grados de libertad mayor es la media', 0),
(@id_question_21, 'B', 'cuanto mayor es el número de grados de libertad menor es la media', 0),
(@id_question_21, 'C', 'no se modifica la media al aumentar los grados de libertad', 1);

-- Pregunta 22
DECLARE @id_question_22 INT;
SET @n_question = 22;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'En un centro escolar con 500 alumnos en cada asignatura y 400 mujeres en cada una, ¿cuántos varones por asignatura debe tener una muestra de 100 alumnos con la misma proporción?',
NULL,
'Centro escolar: 1000 alumnos\nProporción de varones del centro: 200/1000= 0,20\n100 varones en cada asignatura\nMuestra: 100 alumnos\nNúmero total de varones: 100 x 0,20 = 20\n10 varones en cada asignatura'
);

SET @id_question_22 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_22, 'A', '5', 0),
(@id_question_22, 'B', '10', 1),
(@id_question_22, 'C', '40', 0);

-- Pregunta 23
DECLARE @id_question_23 INT;
SET @n_question = 23;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Si el error de estimación máximo es 2, n = 144 y Sn-1 = 12,24, el nivel de confianza es:',
NULL,
NULL
);

SET @id_question_23 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_23, 'A', '0,95', 1),
(@id_question_23, 'B', '0,975', 0),
(@id_question_23, 'C', '0,99', 0);

-- Pregunta 24
DECLARE @id_question_24 INT;
SET @n_question = 24;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'En un estudio sobre el optimismo adolescente con IC = 2,8 y media = 16, ¿cuáles son los límites del intervalo al 95%?',
NULL,
NULL
);

SET @id_question_24 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_24, 'A', '10,4 y 21,6', 0),
(@id_question_24, 'B', '13,2 y 18,8', 0),
(@id_question_24, 'C', '14,6 y 17,4', 1);

-- Pregunta 25
DECLARE @id_question_25 INT;
SET @n_question = 25;

INSERT INTO exams_questions (id_exam, id_subjects, n_question, question, topic, correction)
VALUES (
@id_exam,
4,
@n_question,
'Los límites del IC para la proporción de estudiantes a favor de la reforma son 0,45 y 0,55. ¿Cuál es el error de estimación máximo?',
NULL,
NULL
);

SET @id_question_25 = SCOPE_IDENTITY();

INSERT INTO exams_questions_answers (id_question, letter, answer, correct) VALUES
(@id_question_25, 'A', '0,025', 0),
(@id_question_25, 'B', '0,05', 1),
(@id_question_25, 'C', 'no se puede calcular', 0);

