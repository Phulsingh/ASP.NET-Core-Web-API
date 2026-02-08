SELECT * FROM Regions


INSERT INTO [NZWalks].[dbo].[Regions]
(
 Id,
 Name,
 Code, 
 RegionImageUrl
)
VALUES
(
     NEWID(),
    'Wellington',
    'WLG',
    'https://www.google.com/imgres?q=Region%20Image%20Url&imgurl=https%3A%2F%2Fwww.shutterstock.com%2Fimage-vector%2Fvector-map-mena-region-middle-260nw-2693538831.jpg&imgrefurl=https%3A%2F%2Fwww.shutterstock.com%2Fsearch%2Fworld-regions-countries&docid=VZIoTdMTYi3N4M&tbnid=h8JHowNo9oY0jM&vet=12ahUKEwirlbrH2ceSAxXIRmwGHb4CH2EQnPAOegQIUBAB..i&w=559&h=280&hcb=2&ved=2ahUKEwirlbrH2ceSAxXIRmwGHb4CH2EQnPAOegQIUBAB'
),
(
    NEWID(),
    'Christchurch',
    'CHC',
    'https://www.google.com/imgres?q=Region%20Image%20Url&imgurl=https%3A%2F%2Fwww.researchgate.net%2Fpublication%2F364306822%2Ffigure%2Ffig1%2FAS%3A11431281089181912%401665457553572%2FThe-geographical-locations-of-both-Punjab-and-Haryana-states-India-selected-for-this.png&imgrefurl=https%3A%2F%2Fwww.researchgate.net%2Ffigure%2FThe-geographical-locations-of-both-Punjab-and-Haryana-states-India-selected-for-this_fig1_364306822&docid=vgA7mEBp-UI9sM&tbnid=6mpvBrjT-b3FAM&vet=12ahUKEwirlbrH2ceSAxXIRmwGHb4CH2EQnPAOegQIQhAB..i&w=850&h=692&hcb=2&ved=2ahUKEwirlbrH2ceSAxXIRmwGHb4CH2EQnPAOegQIQhAB'
),
(
    NEWID(),
    'Queenstown',
    'ZQN',
    'https://www.google.com/imgres?q=Region%20Image%20Url&imgurl=https%3A%2F%2Fwww.researchgate.net%2Fpublication%2F24421019%2Ffigure%2Ffig2%2FAS%3A781594537238537%401563358067783%2FMap-of-Cameroon-showing-the-10-administrative-regions-and-the-health-districts-of-Ebolowa.png&imgrefurl=https%3A%2F%2Fwww.researchgate.net%2Ffigure%2FMap-of-Cameroon-showing-the-10-administrative-regions-and-the-health-districts-of-Ebolowa_fig2_24421019&docid=YVHBLSuH6C9i1M&tbnid=n7fZro5MAmnLPM&vet=12ahUKEwirlbrH2ceSAxXIRmwGHb4CH2EQnPAOegUIgQEQAQ..i&w=753&h=919&hcb=2&ved=2ahUKEwirlbrH2ceSAxXIRmwGHb4CH2EQnPAOegUIgQEQAQ'
);