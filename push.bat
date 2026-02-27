@echo off
cd /d D:\csharpsource\practice\KepsHMI\KepsHIM-OpenCode

echo === Step 1: git init === > push_log.txt
git init >> push_log.txt 2>&1

echo === Step 2: git add . === >> push_log.txt
git add . >> push_log.txt 2>&1

echo === Step 3: git commit === >> push_log.txt
git commit -m "Initial commit" >> push_log.txt 2>&1

echo === Step 4: set remote === >> push_log.txt
git remote add origin https://github.com/ywl125/KepsHIM-OpenCode.git >> push_log.txt 2>&1

echo === Step 5: git push === >> push_log.txt
git push -u origin main >> push_log.txt 2>&1

echo === DONE === >> push_log.txt
notepad push_log.txt
