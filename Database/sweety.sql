--
-- PostgreSQL database dump
--

-- Dumped from database version 13.6
-- Dumped by pg_dump version 13.6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: hash_post; Type: TABLE; Schema: public; Owner: sweety_admin
--

CREATE TABLE public.hash_post (
    hash_id bigint NOT NULL,
    post_id bigint NOT NULL
);


ALTER TABLE public.hash_post OWNER TO sweety_admin;

--
-- Name: hashtags; Type: TABLE; Schema: public; Owner: sweety_admin
--

CREATE TABLE public.hashtags (
    hashtag_id bigint NOT NULL,
    hashtag_name character varying NOT NULL
);


ALTER TABLE public.hashtags OWNER TO sweety_admin;

--
-- Name: hashtags_hashtag_id_seq; Type: SEQUENCE; Schema: public; Owner: sweety_admin
--

CREATE SEQUENCE public.hashtags_hashtag_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hashtags_hashtag_id_seq OWNER TO sweety_admin;

--
-- Name: hashtags_hashtag_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sweety_admin
--

ALTER SEQUENCE public.hashtags_hashtag_id_seq OWNED BY public.hashtags.hashtag_id;


--
-- Name: likes; Type: TABLE; Schema: public; Owner: sweety_admin
--

CREATE TABLE public.likes (
    id bigint NOT NULL,
    created_at timestamp with time zone NOT NULL,
    comment integer,
    user_id bigint NOT NULL,
    post_id bigint NOT NULL
);


ALTER TABLE public.likes OWNER TO sweety_admin;

--
-- Name: likes_id_seq; Type: SEQUENCE; Schema: public; Owner: sweety_admin
--

CREATE SEQUENCE public.likes_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.likes_id_seq OWNER TO sweety_admin;

--
-- Name: likes_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sweety_admin
--

ALTER SEQUENCE public.likes_id_seq OWNED BY public.likes.id;


--
-- Name: posts; Type: TABLE; Schema: public; Owner: sweety_admin
--

CREATE TABLE public.posts (
    post_id bigint NOT NULL,
    type_of_post character varying NOT NULL,
    user_id integer NOT NULL,
    posted_at timestamp with time zone NOT NULL
);


ALTER TABLE public.posts OWNER TO sweety_admin;

--
-- Name: posts_post_id_seq; Type: SEQUENCE; Schema: public; Owner: sweety_admin
--

CREATE SEQUENCE public.posts_post_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.posts_post_id_seq OWNER TO sweety_admin;

--
-- Name: posts_post_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sweety_admin
--

ALTER SEQUENCE public.posts_post_id_seq OWNED BY public.posts.post_id;


--
-- Name: users; Type: TABLE; Schema: public; Owner: sweety_admin
--

CREATE TABLE public.users (
    user_id bigint NOT NULL,
    user_name character varying NOT NULL,
    password character varying NOT NULL,
    email character varying NOT NULL,
    followers integer NOT NULL,
    following integer NOT NULL
);


ALTER TABLE public.users OWNER TO sweety_admin;

--
-- Name: users_user_id_seq; Type: SEQUENCE; Schema: public; Owner: sweety_admin
--

CREATE SEQUENCE public.users_user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_user_id_seq OWNER TO sweety_admin;

--
-- Name: users_user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: sweety_admin
--

ALTER SEQUENCE public.users_user_id_seq OWNED BY public.users.user_id;


--
-- Name: hashtags hashtag_id; Type: DEFAULT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.hashtags ALTER COLUMN hashtag_id SET DEFAULT nextval('public.hashtags_hashtag_id_seq'::regclass);


--
-- Name: likes id; Type: DEFAULT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.likes ALTER COLUMN id SET DEFAULT nextval('public.likes_id_seq'::regclass);


--
-- Name: posts post_id; Type: DEFAULT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.posts ALTER COLUMN post_id SET DEFAULT nextval('public.posts_post_id_seq'::regclass);


--
-- Name: users user_id; Type: DEFAULT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.users ALTER COLUMN user_id SET DEFAULT nextval('public.users_user_id_seq'::regclass);


--
-- Data for Name: hash_post; Type: TABLE DATA; Schema: public; Owner: sweety_admin
--

COPY public.hash_post (hash_id, post_id) FROM stdin;
1	1
\.


--
-- Data for Name: hashtags; Type: TABLE DATA; Schema: public; Owner: sweety_admin
--

COPY public.hashtags (hashtag_id, hashtag_name) FROM stdin;
2	happy
1	smile
\.


--
-- Data for Name: likes; Type: TABLE DATA; Schema: public; Owner: sweety_admin
--

COPY public.likes (id, created_at, comment, user_id, post_id) FROM stdin;
2	2022-03-17 15:03:42.254+05:30	\N	1	1
3	2022-03-17 15:26:44.658+05:30	\N	2	2
\.


--
-- Data for Name: posts; Type: TABLE DATA; Schema: public; Owner: sweety_admin
--

COPY public.posts (post_id, type_of_post, user_id, posted_at) FROM stdin;
1	string	1	2022-03-17 14:58:14.838+05:30
2	image	1	2022-03-17 15:14:50.346+05:30
3	video	2	2022-03-17 15:19:03.484+05:30
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: sweety_admin
--

COPY public.users (user_id, user_name, password, email, followers, following) FROM stdin;
1	Ruchitha	password	ruchi@gmail.com	200	100
2	Supriya	56789	supu@gmail.com	300	150
\.


--
-- Name: hashtags_hashtag_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sweety_admin
--

SELECT pg_catalog.setval('public.hashtags_hashtag_id_seq', 2, true);


--
-- Name: likes_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sweety_admin
--

SELECT pg_catalog.setval('public.likes_id_seq', 3, true);


--
-- Name: posts_post_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sweety_admin
--

SELECT pg_catalog.setval('public.posts_post_id_seq', 3, true);


--
-- Name: users_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: sweety_admin
--

SELECT pg_catalog.setval('public.users_user_id_seq', 2, true);


--
-- Name: hashtags hashtags_pkey; Type: CONSTRAINT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.hashtags
    ADD CONSTRAINT hashtags_pkey PRIMARY KEY (hashtag_id);


--
-- Name: likes likes_pkey; Type: CONSTRAINT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.likes
    ADD CONSTRAINT likes_pkey PRIMARY KEY (id);


--
-- Name: posts posts_pkey; Type: CONSTRAINT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.posts
    ADD CONSTRAINT posts_pkey PRIMARY KEY (post_id);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);


--
-- Name: hash_post hash_id; Type: FK CONSTRAINT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.hash_post
    ADD CONSTRAINT hash_id FOREIGN KEY (hash_id) REFERENCES public.hashtags(hashtag_id) NOT VALID;


--
-- Name: likes post_id; Type: FK CONSTRAINT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.likes
    ADD CONSTRAINT post_id FOREIGN KEY (post_id) REFERENCES public.posts(post_id) NOT VALID;


--
-- Name: hash_post post_id; Type: FK CONSTRAINT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.hash_post
    ADD CONSTRAINT post_id FOREIGN KEY (post_id) REFERENCES public.posts(post_id) NOT VALID;


--
-- Name: posts user_id; Type: FK CONSTRAINT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.posts
    ADD CONSTRAINT user_id FOREIGN KEY (user_id) REFERENCES public.users(user_id) NOT VALID;


--
-- Name: likes user_id; Type: FK CONSTRAINT; Schema: public; Owner: sweety_admin
--

ALTER TABLE ONLY public.likes
    ADD CONSTRAINT user_id FOREIGN KEY (user_id) REFERENCES public.users(user_id) NOT VALID;


--
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: postgres
--

GRANT USAGE ON SCHEMA public TO sweety_admin;


--
-- PostgreSQL database dump complete
--

